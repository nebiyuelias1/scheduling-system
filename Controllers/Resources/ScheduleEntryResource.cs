using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Controllers.Resources
{
    public class ScheduleEntryResource
    {
        public int Id { get; set; }
        public CourseResource Course { get; set; }
        public InstructorResource Instructor { get; set; }
        public RoomResource Room { get; set; }
        public KeyValuePairResource Type { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public int RoomId { get; set; }
        public int TypeId { get; set; }
        public int Period { get; set; }
        public int Duration { get; set; }
    }
}