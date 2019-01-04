using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Models
{
    public class AcademicYear
    {
        public int Id { get; set; }
        public int GcYear { get; set; }
        public int EtYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<AcademicSemester> AcademicSemesters { get; set; }

        public AcademicYear()
        {
            AcademicSemesters = new Collection<AcademicSemester>();
        }
    }
}