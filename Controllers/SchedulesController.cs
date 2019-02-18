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
        private readonly IGeneticAlgorithm algorithm;

        public SchedulesController(IGeneticAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var schedule = await algorithm.GenerateScheduleForSection(id);

            return Ok(schedule.TimeTable);
        }
    }
}