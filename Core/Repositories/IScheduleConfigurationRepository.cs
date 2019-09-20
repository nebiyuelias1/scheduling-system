using System.Threading.Tasks;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface IScheduleConfigurationRepository : IRepository<ScheduleConfiguration>
    {
        Task<ScheduleConfiguration> GetScheduleConfiguration(int admissionLevelId, int programTypeId);
        Task<ScheduleConfiguration> GetScheduleConfiguration(ScheduleConfigurationQuery query);
    }
}