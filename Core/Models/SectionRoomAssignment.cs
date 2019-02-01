using System.ComponentModel.DataAnnotations.Schema;


namespace SchedulingSystem.Core.Models
{
    [Table("SectionRoomAssignments")]
    public class SectionRoomAssignment
    {
        public Section Section { get; set; }     
        public Room Room { get; set; }
        public Type Type { get; set; }
        public int SectionId { get; set; }
        public int RoomId { get; set; }
        public int TypeId { get; set; }
    }
}