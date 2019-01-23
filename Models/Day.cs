using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Models
{
    public class Day
    {
        public int Id { get; set; }
        public WeekDay WeekDay { get; set; }
        public ICollection<ScheduleEntry> Periods { get; set; }

        public Day()
        {
            Periods = new Collection<ScheduleEntry>();
        }
    }
}