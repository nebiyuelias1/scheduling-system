using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Models;
using SchedulingSystem.Persistence;
using SchedulingSystem.Controllers.Resources;
using AutoMapper;

namespace SchedulingSystem.Controllers
{
    [Route("/api/departments")]
    public class DepartmentsController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IMapper mapper;

        public DepartmentsController(SchedulingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult New([FromBody] DepartmentResource departmentResource)
        {
            var department = mapper.Map<DepartmentResource, Department>(departmentResource);

            context.Departments.Add(department);
            context.SaveChanges();

            var result = mapper.Map<Department, DepartmentResource>(department);

            return Ok(result);
        }
    }
}