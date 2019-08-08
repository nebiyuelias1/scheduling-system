using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Core.Models
{
    public class DaySession
    {
        public int Id { get; set; }
        public List<ScheduleEntry> ScheduleEntries { get; set; }
        public DaySchedule DaySchedule { get; set; }
        public int DayScheduleId { get; set; }

        public DaySession(int capacity)
        {
            ScheduleEntries = new List<ScheduleEntry>(capacity);
        }
        public DaySession()
        {
            ScheduleEntries = new List<ScheduleEntry>();
        }
    }
}