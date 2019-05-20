using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/courses")]
    public class CoursesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public CoursesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveCourseResource courseResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = mapper.Map<SaveCourseResource, Course>(courseResource);
            
            unitOfWork.Courses.Add(course);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Course, SaveCourseResource>(course);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var course = await unitOfWork.Courses.Get(id);
            if (course == null)
                return NotFound();

            var result = mapper.Map<Course, CourseResource>(course);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await unitOfWork.Courses.GetCoursesWithCurriculum();

            if (courses == null)
                return NotFound();

            var result = mapper.Map<IEnumerable<Course>, IEnumerable<CourseResource>>(courses);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await unitOfWork.Courses.Get(id);
            
            if (course == null)
                return NotFound();

            unitOfWork.Courses.Remove(course);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveCourseResource resouce)
        {
            var course = await unitOfWork.Courses.Get(id);
            
            if (course == null)
                return NotFound();

            resouce.Id = course.Id;
            mapper.Map<SaveCourseResource, Course>(resouce, course);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Course, CourseResource>(course);
            return Ok(result);
        }

    }
}