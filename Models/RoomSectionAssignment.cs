namespace SchedulingSystem.Models
{
    public class RoomSectionAssignment
    {
        public Section Section { get; set; }     
        public Room Room { get; set; }
        public RoomAssignmentType Type { get; set; }
        public int SectionId { get; set; }
        public int RoomId { get; set; }
        public int TypeId { get; set; }
    }
}