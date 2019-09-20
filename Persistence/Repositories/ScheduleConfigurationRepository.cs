using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class ScheduleConfigurationRepository : Repository<ScheduleConfiguration>, IScheduleConfigurationRepository
    {
        public ScheduleConfigurationRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<ScheduleConfiguration> GetScheduleConfiguration(int admissionLevelId, int programTypeId)
        {
            return await SchedulingDbContext
                    .ScheduleConfigurations
                    .Include(s => s.Durations)
                    .Include(s => s.AdmissionLevel)
                    .Include(s => s.ProgramType)
                    .SingleOrDefaultAsync(s => s.AdmissionLevelId == admissionLevelId && s.ProgramTypeId == programTypeId);
        }

        public async Task<ScheduleConfiguration> GetScheduleConfiguration(ScheduleConfigurationQuery queryObj)
        {
            
            var section = await SchedulingDbContext
                                .Sections
                                .SingleOrDefaultAsync(s => s.Id == queryObj.SectionId);

            var result =  await SchedulingDbContext
                            .ScheduleConfigurations
                            .Include(s => s.Durations)
                            .Include(s => s.AdmissionLevel)
                            .Include(s => s.ProgramType)
                            .SingleOrDefaultAsync(s => s.AdmissionLevelId == section.AdmissionLevelId &&
                                                s.ProgramTypeId == section.ProgramTypeId);

            if (queryObj.OnlyClassType)
            {
                result.Durations = result.Durations.Where(d => d.Type == DurationType.Class).ToList();
            }

            return result;
        }
    }
}