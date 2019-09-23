using SchedulingSystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchedulingSystem.Core.Repositories
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Task<Schedule> GetScheduleForSection(int sectionId);
    }
}