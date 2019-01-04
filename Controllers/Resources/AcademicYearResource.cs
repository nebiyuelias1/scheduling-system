using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Controllers.Resources
{
    public class AcademicYearResource
    {
        public int Id { get; set; }
        public string GcYear { get; set; }
        public string EtYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<AcademicSemesterResource> AcademicSemesters { get; set; }

        public AcademicYearResource()
        {
            AcademicSemesters = new Collection<AcademicSemesterResource>();
        }
    }
}