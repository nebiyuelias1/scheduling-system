using System;

namespace SchedulingSystem.Controllers.Resources
{
    public class SaveAcademicSemesterResource
    {
        public int Id { get; set; }
        public byte Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AcademicYearId { get; set; }
    }
}