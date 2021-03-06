using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("api/[controller]")]
    public class CourseOfferingsController : Controller
    {
        private readonly IHelper helper;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CourseOfferingsController(IUnitOfWork unitOfWork, IHelper helper, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.helper = helper;
            this.mapper = mapper;
        }

        public async Task<QueryResultResource<CourseOfferingResource>> GetAll(CourseOfferingQueryResource filterResource)
        {
            var filter = Mapper.Map<CourseOfferingQueryResource, CourseOfferingQuery>(filterResource);
            var currentActiveSemester = await unitOfWork.AcademicSemesters.GetCurrentAcademicSemester();

            filter.SemesterId = currentActiveSemester.Id;

            var courseOfferings = await unitOfWork.CourseOfferings.GetCourseOfferingsWithRelatedData(filter);
            
            return mapper.Map<QueryResult<CourseOffering>, QueryResultResource<CourseOfferingResource>>(courseOfferings);
        }

        [HttpGet("create/{id}")]
        public async Task<IActionResult> Create(int id)
        {
            var currentActiveSemester = await unitOfWork.AcademicSemesters.GetCurrentAcademicSemester();

            if (currentActiveSemester == null)
                return BadRequest();

            var sections = (await unitOfWork.Sections.GetSections
            (
                new SectionQuery
                {
                    DepartmentId = id,
                }
            )).Items;

            if (sections == null)
                return BadRequest();

            foreach (var section in sections)
            {
                var sectionYear = helper
                    .CalculateCurrentYearOfSection(Convert.ToInt32(currentActiveSemester.AcademicYear.EtYear), section.EntranceYear);

                var courses = await unitOfWork.Courses
                    .GetCoursesForCurrentSemester(sectionYear, currentActiveSemester.Semester, section.CurriculumId);

                foreach (var course in courses)
                {
                    if (!unitOfWork.CourseOfferings.DoesCourseOfferingExist(currentActiveSemester.Id, course.Id, section.Id))
                    {
                        unitOfWork.CourseOfferings
                        .Add(CreateCourseOffering(course, section, currentActiveSemester));
                    }
                }
            }

            await unitOfWork.CompleteAsync();

            var courseOfferings = await unitOfWork.CourseOfferings.GetCourseOfferingsWithRelatedData(new CourseOfferingQuery());

            var result = mapper.Map<IEnumerable<CourseOffering>, IEnumerable<CourseOfferingResource>>(courseOfferings.Items);

            return Ok(result);
        }



        [HttpPost]
        public async Task<IActionResult> Assign([FromBody] SaveAssignmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseOffering = await unitOfWork.CourseOfferings.GetCourseOffering(resource.CourseOfferingId);

            if (courseOffering == null)
                return NotFound();

            if (resource.InstructorId.HasValue)
            {
                var assignment = courseOffering.Instructors.SingleOrDefault(i => i.TypeId == resource.TypeId);

                if (assignment == null)
                    return NotFound();

                assignment.InstructorId = resource.InstructorId;
                await unitOfWork.CompleteAsync();

                assignment = await unitOfWork.CourseOfferingInstructorAssignments.GetInstructorAssignment(resource.CourseOfferingId, resource.InstructorId.Value, resource.TypeId);

                return Ok(mapper.Map<InstructorAssignment, InstructorAssignmentResource>(assignment));
            }
            else if (resource.RoomId.HasValue)
            {
                var assignment = courseOffering.Rooms.SingleOrDefault(i => i.TypeId == resource.TypeId);

                if (assignment == null)
                    return NotFound();

                assignment.RoomId = resource.RoomId;
                await unitOfWork.CompleteAsync();

                return Ok(resource.RoomId);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var courseOffering = await unitOfWork.CourseOfferings.Get(id);
            if (courseOffering == null)
                return NotFound();

            unitOfWork.CourseOfferings.Remove(courseOffering);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseOffering(int id)
        {
            var courseOffering = await unitOfWork.CourseOfferings.GetCourseOffering(id);

            if (courseOffering == null)
                return NotFound();

            var result = Mapper.Map<CourseOffering, CourseOfferingResource>(courseOffering);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> RemoveAssignment(int id, [FromBody] RemoveAssignmentResource resource)
        {
            var courseOffering = await unitOfWork.CourseOfferings.GetCourseOffering(id);

            if (courseOffering == null)
                return NotFound();

            if (resource.RoomId.HasValue)
            {
                var assignment = courseOffering.Rooms.SingleOrDefault(r => r.TypeId == resource.TypeId);
                
                if (assignment == null)
                    return NotFound();
                
                assignment.RoomId = null;
                await unitOfWork.CompleteAsync();

                return Ok(assignment.Id);
            }
            else
            {
                var assignment = courseOffering.Instructors.SingleOrDefault(i => i.TypeId == resource.TypeId);

                if (assignment == null)
                    return NotFound();

                assignment.InstructorId = null;
                await unitOfWork.CompleteAsync();

                return Ok(assignment.Id);
            }
        }

        private CourseOffering CreateCourseOffering(Course course, Section section, AcademicSemester currentActiveSemester)
        {
            var courseOffering = new CourseOffering
            {
                SectionId = section.Id,
                CourseId = course.Id,
                AcademicSemesterId = currentActiveSemester.Id
            };

            if (course.Lecture > 0)
            {
                courseOffering.Instructors.Add(new InstructorAssignment
                {
                    TypeId = 1
                });
                courseOffering.Rooms.Add(new CourseOfferingRoomAssignment
                {
                    TypeId = 1
                });
            }

            if (course.Lab > 0)
            {
                courseOffering.Instructors.Add(new InstructorAssignment
                {
                    TypeId = 2
                });
                courseOffering.Rooms.Add(new CourseOfferingRoomAssignment
                {
                    TypeId = 2,
                    LabTypeId = course.LabTypeId
                });
            }

            if (course.Tutor > 0)
            {
                courseOffering.Instructors.Add(new InstructorAssignment
                {
                    TypeId = 3
                });
                courseOffering.Rooms.Add(new CourseOfferingRoomAssignment
                {
                    TypeId = 3
                });
            }

            return courseOffering;
        }
    }
}