using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Controllers.Resources
{
    public class ScheduleResource
    {
        public int Id { get; set; }
        
        public AcademicSemesterResource AcademicSemester { get; set; }

        public SectionResource Section { get; set; }
        
        public ICollection<DayScheduleResource> TimeTable { get; set; }

        public double Fitness { get; set; }

        public int AcademicSemesterId { get; set; }

        public int SectionId { get; set; }

        public ScheduleResource()
        {
            TimeTable = new Collection<DayScheduleResource>();
        }

    }
}