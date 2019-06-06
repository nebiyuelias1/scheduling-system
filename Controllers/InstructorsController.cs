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

        [HttpGet("{userId}")]
        public async Task<IActionResult> Create(string userId)
        {
            var instructor = new Instructor 
            {
                UserId = userId
            };

            unitOfWork.Instructors.Add(instructor);
            await unitOfWork.CompleteAsync();

            var result = Mapper.Map<Instructor, InstructorResource>(instructor);
            return Ok(result);
        }

        
        [HttpGet]
        public async Task<QueryResultResource<InstructorResource>> GetInstructors(InstructorQueryResource filterResource)
        {
            var filter = Mapper.Map<InstructorQueryResource, InstructorQuery>(filterResource);

            var result = await unitOfWork.Instructors.GetInstructors(filter);

            return mapper.Map<QueryResult<Instructor>, QueryResultResource<InstructorResource>>(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var instructor = await unitOfWork.Instructors.Get(id);

            if (instructor == null || !instructor.IsActive)
                return NotFound();

            instructor.MakeInactive();
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}