using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;
using SchedulingSystem.Controllers.Resources;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using SchedulingSystem.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SchedulingSystem.Controllers
{
    [Route("/api/departments")]
    public class DepartmentsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public DepartmentsController(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await unitOfWork.Departments.GetDepartments();
            if (departments == null)
                return NotFound();

            var departmentsResource = mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(departments);
            return Ok(departmentsResource);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentResource departmentResource)
        {
            var department = mapper.Map<DepartmentResource, Department>(departmentResource);

            unitOfWork.Departments.Add(department);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Department, DepartmentResource>(department);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Assign(int id, [FromBody] DepartmentHeadAssignmentResource resource)
        {
            var department = await unitOfWork.Departments.Get(id);
            var user = await userManager.Users
                            .Include(u => u.Contact)
                            .SingleOrDefaultAsync(u => u.Id == resource.UserId);

            if (department == null || user == null)
                return NotFound();

            if (id != user.Contact.DepartmentId)
                return BadRequest();

            department.DepartmentHeadId = resource.UserId;
            await unitOfWork.CompleteAsync();

            var result = await userManager.AddToRoleAsync(user, "Department Head"); 
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAssignment(int id)
        {
            var department = await unitOfWork.Departments.Get(id);

            if (department == null)
                return NotFound();

            var user = await userManager.FindByIdAsync(department.DepartmentHeadId);
            var result = await userManager.RemoveFromRoleAsync(user, "Department Head");

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            department.DepartmentHeadId = null;
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}