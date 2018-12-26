using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/[controller]")]
    public class ProgramsController : Controller
    {
        private readonly SchedulingDbContext context;

        public ProgramsController(SchedulingDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPrograms()
        {
            var programs = await context.ProgramTypes.ToListAsync();

            if (programs == null)
                return NotFound();

            return Ok(programs);
        }
    }
}