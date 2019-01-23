namespace SchedulingSystem.Models
{
    public class ScheduleEntry
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
        public Room Room { get; set; }
        public Type Type { get; set; }
        public Day Day { get; set; }
        public byte Period { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public int RoomId { get; set; }
        public int TypeId { get; set; }
        public int DayId { get; set; }
    }
}