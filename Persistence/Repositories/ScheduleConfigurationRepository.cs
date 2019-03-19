using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                    .SingleOrDefaultAsync(s => s.AdmissionLevelId == admissionLevelId && s.ProgramTypeId == programTypeId);
        }

        public async Task<ScheduleConfiguration> GetScheduleConfigurationForSection(int sectionId)
        {
            var section = await SchedulingDbContext
                                .Sections
                                .SingleOrDefaultAsync(s => s.Id == sectionId);

            return await GetScheduleConfiguration(section.AdmissionLevelId, section.ProgramTypeId);
        }
    }
}