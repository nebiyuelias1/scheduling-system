using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class WeekDayRepository: Repository<WeekDay>, IWeekDayRepository
    {
        public WeekDayRepository(SchedulingDbContext context): base(context)
        {
        }
    }
}