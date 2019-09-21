using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Controllers.Resources
{
    public class SaveDaySessionResource
    {
        public int Id { get; set; }
        public ICollection<SaveScheduleEntryResource> ScheduleEntries { get; set; }

        public SaveDaySessionResource()
        {
            ScheduleEntries = new Collection<SaveScheduleEntryResource>();
        }
    }
}