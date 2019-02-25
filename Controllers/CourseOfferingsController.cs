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
        private readonly SchedulingDbContext context;
        private readonly IHelper helper;
        private readonly IMapper mapper;

        public CourseOfferingsController(SchedulingDbContext context, IHelper helper, IMapper mapper)
        {
            this.context = context;
            this.helper = helper;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Get()
        {
            var currentActiveSemester = await context.AcademicSemesters
                                        .Include(s => s.AcademicYear)
                                        .SingleOrDefaultAsync(a => a.IsCurrentSemester);

            if (currentActiveSemester == null)
                return BadRequest();

            var courseOfferings = await context.CourseOfferings
                                    .Include(co => co.Instructors)
                                        .ThenInclude(i => i.Instructor)
                                    .Include(co => co.Instructors)
                                        .ThenInclude(i => i.Type)
                                    .Include(co => co.Course)
                                    .Include(co => co.Section)
                                    .Where(co => co.AcademicSemesterId == currentActiveSemester.Id)
                                    .ToListAsync();

            var result = mapper.Map<IEnumerable<CourseOffering>, IEnumerable<CourseOfferingResource>>(courseOfferings);
            
            return Ok(result);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            var currentActiveSemester = await context.AcademicSemesters
                                        .Include(s => s.AcademicYear)
                                        .SingleOrDefaultAsync(a => a.IsCurrentSemester);
            
            if (currentActiveSemester == null)
                return BadRequest();
            
            var sections = await context.Sections.ToListAsync();

            if (sections == null)
                return BadRequest();

            foreach (var section in sections)
            {
                var sectionYear = helper.CalculateCurrentYearOfSection(Convert.ToInt32(currentActiveSemester.AcademicYear.EtYear), section.EntranceYear);

                var courses = await context.Courses
                                .Where(c => c.DeliveryYear == sectionYear && c.DeliverySemester == currentActiveSemester.Semester)
                                .ToListAsync();

                foreach (var course in courses)
                {
                    var doesCourseOfferingExist = context.CourseOfferings.Any(co => 
                                                co.AcademicSemesterId == currentActiveSemester.Id &&
                                                co.CourseId == course.Id &&
                                                co.SectionId == section.Id);
                    
                    if (!doesCourseOfferingExist)
                    {
                        context.CourseOfferings.Add(new CourseOffering 
                        {
                            SectionId = section.Id,
                            CourseId = course.Id,
                            AcademicSemesterId = currentActiveSemester.Id
                        });
                    }
                }
            }

            context.SaveChanges();

            var courseOfferings = await context.CourseOfferings
                                    .Include(co => co.Instructors)
                                    .Include(co => co.Course)
                                    .Include(co => co.Section)
                                    .Where(co => co.AcademicSemesterId == currentActiveSemester.Id)
                                    .ToListAsync();

            var result = mapper.Map<IEnumerable<CourseOffering>, IEnumerable<CourseOfferingResource>>(courseOfferings);
            
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> AssignInstructor([FromBody] SaveInstructorAssignmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courseOffering = mapper.Map<SaveInstructorAssignmentResource, InstructorAssignment>(resource);

            context.CourseOfferingInstructorAssignments.Add(courseOffering);
            await context.SaveChangesAsync();
            
            courseOffering = await context.CourseOfferingInstructorAssignments
                            .Include(co => co.CourseOffering)
                            .Include(co => co.Instructor)
                            .Include(co => co.Type)
                            .SingleAsync(co => co.CourseOfferingId == resource.CourseOfferingId &&
                            co.InstructorId == resource.InstructorId &&
                            co.TypeId == resource.TypeId);

            var result = mapper.Map<InstructorAssignment, InstructorAssignmentResource>(courseOffering);
            

            return Ok(result);
        }
    }
}