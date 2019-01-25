using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private readonly SchedulingDbContext context;

        public SchedulesController(SchedulingDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetSchedule(int id)
        {

        }
    }
}