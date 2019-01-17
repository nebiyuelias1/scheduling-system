using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/[controller]")]
    public class InstructorsController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IMapper mapper;
        public InstructorsController(SchedulingDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InstructorResource instructorResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var instructor = mapper.Map<InstructorResource, Instructor>(instructorResource);
            
            await context.Instructors.AddAsync(instructor);
            await context.SaveChangesAsync();

            var result = mapper.Map<Instructor, InstructorResource>(instructor);
            
            return Ok(result);
        }

        public async Task<IActionResult> GetInstructors()
        {
            var instructors = await context.Instructors
                                .ToListAsync();

            if (instructors == null)
                return NotFound();

            var result = mapper.Map<IEnumerable<Instructor>, IEnumerable<InstructorResource>>(instructors);

            return Ok(instructors);
        }
    }
}