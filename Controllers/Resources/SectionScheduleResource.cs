using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Controllers.Resources
{
    public class SectionScheduleResource
    {
        public int Id { get; set; }
        
        public AcademicSemesterResource AcademicSemester { get; set; }
        
        public ICollection<DayScheduleResource> TimeTable { get; set; }

        public double Fitness { get; set; }

        public int AcademicSemesterId { get; set; }


        public SectionScheduleResource()
        {
            TimeTable = new Collection<DayScheduleResource>();
        }
    }
}