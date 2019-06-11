using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;
        public InstructorsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructor(int id)
        {
            var instructor = await unitOfWork.Instructors.GetInstructorWithDept(id);

            if (instructor == null)
            {
                return NotFound();
            }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInstructorResource resource)
        {
            var instructor = await unitOfWork.Instructors.Get(id);

            if (instructor == null)
                return NotFound();

            var user = await userManager.FindByIdAsync(instructor.UserId);
            if (user != null)
            {
                user.FirstName = resource.FirstName;
                user.FatherName = resource.FatherName;
                user.GrandFatherName = resource.GrandFatherName;
                user.DepartmentId = resource.DepartmentId;
                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Ok(Mapper.Map<AppUser, AppUserResource>(user));
                }
            }

            return BadRequest(ModelState);
        }
    }
}