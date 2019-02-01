using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace SchedulingSystem.Core.Models
{
    public class Day
    {
        public int Id { get; set; }
        public WeekDay WeekDay { get; set; }
        public ICollection<ScheduleEntry> Periods { get; set; }
        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }

        public Day()
        {
            Periods = new Collection<ScheduleEntry>();
        }
    }
}