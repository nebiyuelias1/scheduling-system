using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(DbContext context) : base(context)
        {
        }

        public async Task<Schedule> GetScheduleForSection(int sectionId)
        {
            return await SchedulingDbContext.Schedules
                        .Include(s => s.TimeTable)
                            .ThenInclude(t => t.WeekDay)
                        .Include(s => s.TimeTable)
                            .ThenInclude(t => t.DaySessions)
                                .ThenInclude(ds => ds.ScheduleEntries)
                                    .ThenInclude(se => se.Course)
                        .SingleOrDefaultAsync(s => s.SectionId == sectionId);
        }
    }
}