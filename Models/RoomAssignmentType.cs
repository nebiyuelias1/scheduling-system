using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Models
{
    public class RoomAssignmentType
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}