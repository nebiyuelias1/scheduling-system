using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}