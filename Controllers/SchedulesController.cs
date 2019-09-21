using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private readonly IGeneticAlgorithm algorithm;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SchedulesController(IGeneticAlgorithm algorithm, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.algorithm = algorithm;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var schedule = await algorithm.GenerateScheduleForSection(id);

            
            return Ok(mapper.Map<Schedule, ScheduleResource>(schedule));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> SaveSchedule(int id, [FromBody] SaveScheduleResource resource)
        {
            var section = await unitOfWork.Sections.Get(id);
            if (section == null)
            {
                return BadRequest();
            }
            var schedule = mapper.Map<SaveScheduleResource, Schedule>(resource);

            unitOfWork.Schedules.Add(schedule);
            await unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}