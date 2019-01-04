using System;

namespace SchedulingSystem.Controllers.Resources
{
    public class AcademicSemesterResource
    {
        public int Id { get; set; }
        public byte Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}