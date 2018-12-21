using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public Building Building { get; set; }
        public int BuildingId { get; set; }
        public int Size { get; set; }
        public bool IsLabRoom { get; set; }
        public bool IsLectureRoom { get; set; }
        public bool IsSharedRoom { get; set; }
    }
}