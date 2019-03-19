using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface IScheduleConfigurationRepository : IRepository<ScheduleConfiguration>
    {
        Task<ScheduleConfiguration> GetScheduleConfiguration(int admissionLevelId, int programTypeId);
        Task<ScheduleConfiguration> GetScheduleConfigurationForSection(int sectionId);
    }
}