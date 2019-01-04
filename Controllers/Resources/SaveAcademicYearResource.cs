using System;

namespace SchedulingSystem.Controllers.Resources
{
    public class SaveAcademicYearResource
    {
        public int Id { get; set; }
        public string GcYear { get; set; }
        public string EtYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}