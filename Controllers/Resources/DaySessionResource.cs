using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Controllers.Resources
{
    public class DaySessionResource
    {
        public int Id { get; set; }
        public ICollection<ScheduleEntryResource> ScheduleEntries { get; set; }

        public DaySessionResource()
        {
            ScheduleEntries = new Collection<ScheduleEntryResource>();
        }
    }
}