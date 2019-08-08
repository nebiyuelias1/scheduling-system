using SchedulingSystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchedulingSystem.Core.Repositories
{
    public interface IWeekDayRepository : IRepository<WeekDay>
    {
        Task<IEnumerable<WeekDay>> GetFirstWeekDays(int count);
    }
}