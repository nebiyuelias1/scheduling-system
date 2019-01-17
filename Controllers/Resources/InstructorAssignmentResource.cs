namespace SchedulingSystem.Controllers.Resources
{
    public class InstructorAssignmentResource
    {
        public InstructorResource Instructor { get; set; }
        public CourseOfferingResource CourseOffering { get; set; }
        public KeyValuePairResource Type { get; set; }
    }
}