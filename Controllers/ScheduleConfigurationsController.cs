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
    [Route("/api/[controller]")]
    public class ScheduleConfigurationsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ScheduleConfigurationsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveScheduleConfigurationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var scheduleConfiguration = mapper.Map<SaveScheduleConfigurationResource, ScheduleConfiguration>(resource);

            unitOfWork.ScheduleConfigurations.Add(scheduleConfiguration);
            await unitOfWork.CompleteAsync();

            scheduleConfiguration =  await unitOfWork
                                        .ScheduleConfigurations
                                        .GetScheduleConfiguration(resource.AdmissionLevelId, resource.ProgramTypeId);

            var result = mapper.Map<ScheduleConfiguration, ScheduleConfigurationResource>(scheduleConfiguration);

            return Ok(result);
        }
    }
}