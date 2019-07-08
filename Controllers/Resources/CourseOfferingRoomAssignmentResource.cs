namespace SchedulingSystem.Controllers.Resources
{
    public class CourseOfferingRoomAssignmentResource
    {
        public RoomResource Room { get; set; }
        public KeyValuePairResource Type { get; set; }
        public KeyValuePairResource LabType { get; set; }
    }
}