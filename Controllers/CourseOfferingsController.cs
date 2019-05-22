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

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var currentActiveSemester = await unitOfWork.AcademicSemesters.GetCurrentAcademicSemester();

            if (currentActiveSemester == null)
                return BadRequest();

            var sections = await unitOfWork.Sections.GetAll();

            if (sections == null)
                return BadRequest();

            foreach (var section in sections)
            {
                var sectionYear = helper.CalculateCurrentYearOfSection(Convert.ToInt32(currentActiveSemester.AcademicYear.EtYear), section.EntranceYear);

                var courses = await unitOfWork.Courses.GetCoursesForCurrentSemester(sectionYear, currentActiveSemester.Semester);

                foreach (var course in courses)
                {

                    if (!unitOfWork.CourseOfferings.DoesCourseOfferingExist(currentActiveSemester.Id, course.Id, section.Id))
                    {
                        unitOfWork.CourseOfferings.Add(new CourseOffering
                        {
                            SectionId = section.Id,
                            CourseId = course.Id,
                            AcademicSemesterId = currentActiveSemester.Id
                        });
                    }
                }
            }

           await unitOfWork.CompleteAsync();

            var courseOfferings = await unitOfWork.CourseOfferings.GetCourseOfferingsWithRelatedData(currentActiveSemester.Id);

            var result = mapper.Map<IEnumerable<CourseOffering>, IEnumerable<CourseOfferingResource>>(courseOfferings);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> AssignInstructor([FromBody] SaveInstructorAssignmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseOffering = mapper.Map<SaveInstructorAssignmentResource, InstructorAssignment>(resource);

            unitOfWork.CourseOfferingInstructorAssignments.Add(courseOffering);
            await unitOfWork.CompleteAsync();

            courseOffering = await unitOfWork.CourseOfferingInstructorAssignments.GetInstructorAssignment(resource.CourseOfferingId, resource.InstructorId, resource.TypeId);

            var result = mapper.Map<InstructorAssignment, InstructorAssignmentResource>(courseOffering);


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
    }
}