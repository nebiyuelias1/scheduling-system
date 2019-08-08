using SchedulingSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingSystem.Core.Repositories
{
    public interface IScheduleEntryRepository : IRepository<ScheduleEntry>
    {
        IEnumerable<ScheduleEntry> GetScheduleEntriesForSemester(int semesterId, int programTypeId, int admissionLevelId);
    }
}
