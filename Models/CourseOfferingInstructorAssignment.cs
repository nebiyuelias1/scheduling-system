namespace SchedulingSystem.Models
{
    public class CourseOfferingInstructorAssignment
    {
        public CourseOffering CourseOffering { get; set; }
        public Instructor Instructor { get; set; }
        public Type Type { get; set; }
        public int CourseOfferingId { get; set; }
        public int InstructorId { get; set; }
        public int TypeId { get; set; }
    }
}