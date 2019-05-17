using System.Collections;
using System.Collections.Generic;
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
    [Route("/api/[controller]")]
    public class InstructorsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public InstructorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InstructorResource instructorResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var instructor = mapper.Map<InstructorResource, Instructor>(instructorResource);

            unitOfWork.Instructors.Add(instructor);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Instructor, InstructorResource>(instructor);

            return Ok(result);
        }

        public async Task<IActionResult> GetInstructors()
        {
            var instructors = await unitOfWork.Instructors.GetAll();

            if (instructors == null)
                return NotFound();

            var result = mapper.Map<IEnumerable<Instructor>, IEnumerable<InstructorResource>>(instructors);

            return Ok(instructors);
        }
    }
}