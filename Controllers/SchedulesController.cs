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
            var scheduleConfiguration = await unitOfWork
                                        .ScheduleConfigurations
                                        .GetScheduleConfigurationForSection(id);

            var schedule = await algorithm.GenerateScheduleForSection(id, scheduleConfiguration);

            var scheduleResource = mapper.Map<Schedule, ScheduleResource>(schedule);
            var scheduleConfigurationResource = mapper.Map<ScheduleConfiguration, ScheduleConfigurationResource>(scheduleConfiguration);

            var timetableResource = new TimetableResource
            {
                Schedule = scheduleResource,
                ScheduleConfiguration = scheduleConfigurationResource
            };

            return Ok(timetableResource);
        }
    }
}