using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingSystem.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        
        public ICollection<Day> Days { get; set; }
        
        public AcademicSemester AcademicSemester { get; set; }
        
        public Section Section { get; set; }
        
        [NotMapped]
        public IDictionary<int, IList<ScheduleEntry>> TimeTable { get; set; }
        
        public int AcademicSemesterId { get; set; }
        
        public int SectionId { get; set; }

        public Schedule()
        {
            Days = new Collection<Day>();
        }
    }
}