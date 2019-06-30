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

        public async Task<IActionResult> Get()
        {
            var currentActiveSemester = await unitOfWork.AcademicSemesters.GetCurrentAcademicSemester();

            if (currentActiveSemester == null)
                return BadRequest();

            var courseOfferings = await unitOfWork.CourseOfferings.GetCourseOfferingsWithRelatedData(currentActiveSemester.Id);

            var result = mapper.Map<IEnumerable<CourseOffering>, IEnumerable<CourseOfferingResource>>(courseOfferings);

            return Ok(result);
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

            var courseOfferings = await unitOfWork.CourseOfferings.GetCourseOfferingsWithRelatedData(currentActiveSemester.Id);

            var result = mapper.Map<IEnumerable<CourseOffering>, IEnumerable<CourseOfferingResource>>(courseOfferings);

            return Ok(result);
        }

        

        [HttpPost]
        public async Task<IActionResult> AssignInstructor([FromBody] SaveInstructorAssignmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseOffering = await unitOfWork.CourseOfferings.GetCourseOffering(resource.CourseOfferingId);

            if (courseOffering == null)
                return NotFound();

            var assignment = courseOffering.Instructors.SingleOrDefault(i => i.TypeId == resource.TypeId);

            if (assignment == null)
                return NotFound();

            assignment.InstructorId = resource.InstructorId;
            await unitOfWork.CompleteAsync();

            assignment = await unitOfWork.CourseOfferingInstructorAssignments.GetInstructorAssignment(resource.CourseOfferingId, resource.InstructorId, resource.TypeId);

            var result = mapper.Map<InstructorAssignment, InstructorAssignmentResource>(assignment);


            return Ok(result);
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
        public async Task<IActionResult> RemoveAssignment(int id, [FromBody] int typeId)
        {
            var courseOffering = await unitOfWork.CourseOfferings.GetCourseOffering(id);

            if (courseOffering == null)
                return NotFound();

            var assignment = courseOffering.Instructors.SingleOrDefault(i => i.TypeId == typeId);

            if (assignment == null)
                return NotFound();

            assignment.InstructorId = null;
            await unitOfWork.CompleteAsync();

            return Ok(assignment.Id);
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
            }

            if (course.Lab > 0)
            {
                courseOffering.Instructors.Add(new InstructorAssignment
                {
                    TypeId = 2
                });
            }

            if (course.Tutor > 0)
            {
                courseOffering.Instructors.Add(new InstructorAssignment
                {
                    TypeId = 3
                });
            }

            return courseOffering;
        }
    }
}