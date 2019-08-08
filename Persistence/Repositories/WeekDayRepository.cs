using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class WeekDayRepository: Repository<WeekDay>, IWeekDayRepository
    {
        public WeekDayRepository(SchedulingDbContext context): base(context)
        {
        }

        public async Task<IEnumerable<WeekDay>> GetFirstWeekDays(int count)
        {
            return await SchedulingDbContext
                            .WeekDays
                            .OrderBy(w => w.Number)
                            .Take(count)
                            .ToListAsync();
        }
    }
}