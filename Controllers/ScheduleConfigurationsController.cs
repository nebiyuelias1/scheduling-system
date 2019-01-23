using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/[controller]")]
    public class ScheduleConfigurationsController : Controller
    {
        private readonly IMapper mapper;
        private readonly SchedulingDbContext context;
        public ScheduleConfigurationsController(IMapper mapper, SchedulingDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveScheduleConfigurationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var scheduleConfiguration = mapper.Map<SaveScheduleConfigurationResource, ScheduleConfiguration>(resource);

            context.ScheduleConfigurations.Add(scheduleConfiguration);
            await context.SaveChangesAsync();

            scheduleConfiguration =  await context.ScheduleConfigurations
                                        .Include(s => s.AdmissionLevel)
                                        .Include(s => s.ProgramType)
                                        .SingleOrDefaultAsync(s => s.AdmissionLevelId == resource.AdmissionLevelId && s.ProgramTypeId == resource.ProgramTypeId);

            var result = mapper.Map<ScheduleConfiguration, ScheduleConfigurationResource>(scheduleConfiguration);

            return Ok(result);
        }
    }
}