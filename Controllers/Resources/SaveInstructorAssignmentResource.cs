namespace SchedulingSystem.Controllers.Resources
{
    public class SaveAssignmentResource
    {
        public int CourseOfferingId { get; set; }
        public int? InstructorId { get; set; }
        public int? RoomId { get; set; }
        public int TypeId { get; set; }
    }
}