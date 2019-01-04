using System;

namespace SchedulingSystem.Models
{
    public class AcademicSemester
    {
        public int Id { get; set; }
        public byte Semester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public int AcademicYearId { get; set; }
    }
}