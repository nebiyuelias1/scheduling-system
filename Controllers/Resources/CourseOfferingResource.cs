namespace SchedulingSystem.Controllers.Resources
{
    public class CourseOfferingResource
    {
        public int Id { get; set; }
        public SectionResource Section { get; set; }
        public InstructorResource Instructor { get; set; }
        public CourseResource Course { get; set; }
        public AcademicSemesterResource AcademicSemester { get; set; }
    }
}