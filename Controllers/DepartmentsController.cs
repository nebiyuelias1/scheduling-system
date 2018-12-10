using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/departments")]
    public class DepartmentsController : Controller
    {
        private readonly SchedulingDbContext _context;

        public DepartmentsController(SchedulingDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public Department New(Department department)
        {
            _context.Add(department);

            return department;
        }
    }
}