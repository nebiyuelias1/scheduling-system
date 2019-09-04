using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Controllers.Resources
{
    public class DayScheduleResource
    {
        public int Id { get; set; }
        public WeekDayResource WeekDay { get; set; }
        public int WeekDayId { get; set; }
        public ICollection<DaySessionResource> DaySessions { get; set; }

        public DayScheduleResource()
        {
            DaySessions = new Collection<DaySessionResource>();
        }
    }
}