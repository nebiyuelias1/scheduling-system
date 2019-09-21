using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Controllers.Resources
{
    public class SaveScheduleResource
    {
        public int Id { get; set; }
        
        public ICollection<SaveDayScheduleResource> TimeTable { get; set; }

        public double Fitness { get; set; }

        public int AcademicSemesterId { get; set; }

        public int SectionId { get; set; }

        public SaveScheduleResource()
        {
            TimeTable = new Collection<SaveDayScheduleResource>();
        }

    }
}