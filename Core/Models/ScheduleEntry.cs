
namespace SchedulingSystem.Core.Models
{
    public class ScheduleEntry
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        public Room Room { get; set; }
        public Type Type { get; set; }
        public DaySession DaySession { get; set; }
        public int DaySessionId { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public int RoomId { get; set; }
        public int TypeId { get; set; }
        public int Period { get; set; }
        public int Duration { get; set; }
    }
}