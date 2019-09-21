using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Controllers.Resources
{
    public class SaveDayScheduleResource
    {
        public int Id { get; set; }
        public int WeekDayId { get; set; }
        public ICollection<SaveDaySessionResource> DaySessions { get; set; }

        public SaveDayScheduleResource()
        {
            DaySessions = new Collection<SaveDaySessionResource>();
        }
    }
}