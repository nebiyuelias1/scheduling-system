using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    public class CollegesController : Controller
    {
        private readonly SchedulingDbContext _context;

        public CollegesController(SchedulingDbContext context)
        {
            this._context = context;
        }

        [Route("/api/colleges")]
        public IEnumerable<College> GetColleges() 
        {
            return _context.Colleges.ToList();
        }
    }
}