using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem.Persistence.Repositories
{
    class ScheduleEntryRepository : Repository<ScheduleEntry>, IScheduleEntryRepository
    {
        public ScheduleEntryRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<ScheduleEntry> GetScheduleEntriesForSemester(int semesterId, int programTypeId, int admissionLevelId)
        {
            return SchedulingDbContext.ScheduleEntries
                .Include(s => s.DaySession)
                    .ThenInclude(d => d.DaySchedule)
                        .ThenInclude(ds => ds.Schedule)
                            .ThenInclude(sc => sc.Section)
                .Include(s => s.DaySession)
                    .ThenInclude(d => d.DaySchedule)
                        .ThenInclude(ds => ds.WeekDay)
                .Where(s => s.DaySession.DaySchedule.Schedule.AcademicSemesterId == semesterId &&
                        s.DaySession.DaySchedule.Schedule.Section.ProgramTypeId == programTypeId &&
                        s.DaySession.DaySchedule.Schedule.Section.AdmissionLevelId == admissionLevelId);
        }
    }
}
