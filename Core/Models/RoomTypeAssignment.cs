using System.ComponentModel.DataAnnotations.Schema;


namespace SchedulingSystem.Core.Models
{
    [Table("RoomTypeAssignments")]
    public class RoomTypeAssignment
    {
        public Room Room { get; set; }
        public Type Type { get; set; }
        public LabType LabType { get; set; }
        public int RoomId { get; set; }
        public int TypeId { get; set; }
        public int? LabTypeId { get; set; }
    }
}