using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IGeneticAlgorithm algorithm;

        public SchedulesController(SchedulingDbContext context, IGeneticAlgorithm algorithm)
        {
            this.context = context;
            this.algorithm = algorithm;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var currentSemester = await context.AcademicSemesters
                                    .Include(a => a.AcademicYear)
                                    .SingleOrDefaultAsync(s => s.IsCurrentSemester);
            
            var schedule = algorithm.GenerateScheduleForSection(id);

            return Ok();
        }
    }
}