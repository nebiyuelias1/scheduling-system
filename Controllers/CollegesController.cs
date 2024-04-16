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
    public class CollegesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public CollegesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetColleges()
        {
            var colleges = await unitOfWork.Colleges.GetColleges();
            if (colleges == null)
                return NotFound();

            var result = mapper.Map<IEnumerable<College>, IEnumerable<CollegeResource>>(colleges);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Assign(int id, [FromBody] CollegeDeanAssignmentResource resource)
        {
            var college = await unitOfWork.Colleges.Get(id);
            var user = await userManager.Users
                            .Include(u => u.Contact)
                            .SingleOrDefaultAsync(u => u.Id == resource.UserId);

            if (college == null || user == null)
                return NotFound();
            
            if (user.Contact.DepartmentId == null)
                return BadRequest();

            var collegeId = (await unitOfWork.Departments.GetDepartment(user.Contact.DepartmentId.GetValueOrDefault())).CollegeId;
            if (college.Id != collegeId)
                return BadRequest();

            college.CollegeDeanId = resource.UserId;
            await unitOfWork.CompleteAsync();

            var result = await userManager.AddToRoleAsync(user, "College Dean");
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAssignemt(int id)
        {
            var college = await unitOfWork.Colleges.Get(id);

            if (college == null)
                return NotFound();

            var user = await userManager.FindByIdAsync(college.CollegeDeanId);
            var result = await userManager.RemoveFromRoleAsync(user, "College Dean");

            if (!result.Succeeded)
                return BadRequest(result.Errors);
                
            college.CollegeDeanId = null;
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}