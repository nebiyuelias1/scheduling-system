using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Persistence;
using Microsoft.EntityFrameworkCore;

namespace SchedulingSystem.Controllers
{
    [Route("/api/[controller]")]
    public class AdmissionLevelsController : Controller
    {
        private readonly SchedulingDbContext context;

        public AdmissionLevelsController(SchedulingDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdmissionLevels()
        {
            var admissionLevels = await context.AdmissionLevels.ToListAsync();
            
            if (admissionLevels == null)
                return NotFound();

            return Ok(admissionLevels);
        }
    }
}