using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/courses")]
    public class CoursesController : Controller
    {
        private readonly IMapper mapper;
        private readonly SchedulingDbContext context;
        public CoursesController(IMapper mapper, SchedulingDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseResource courseResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = mapper.Map<CourseResource, Course>(courseResource);
            
            context.Add(course);
            await context.SaveChangesAsync();

            var result = mapper.Map<Course, CourseResource>(course);

            return Ok(result);
        }
    }
}