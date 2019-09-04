using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Core.Models
{
    public class DaySchedule
    {
        public int Id { get; set; }
        public WeekDay WeekDay { get; set; }
        public int WeekDayId { get; set; }
        public ICollection<DaySession> DaySessions { get; set; }
        public Schedule Schedule { get; set; }
        public int ScheduleId { get; set; }

        public DaySchedule()
        {
            DaySessions = new Collection<DaySession>();
        }
    }
}