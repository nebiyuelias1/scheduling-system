using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("api/[controller]")]
    public class CourseOfferingsController : Controller
    {
        private readonly SchedulingDbContext context;
        public CourseOfferingsController(SchedulingDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var sections = await context.Sections.ToListAsync();
            return Ok();
        }
    }
}