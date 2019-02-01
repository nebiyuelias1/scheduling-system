using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace SchedulingSystem.Core.Models
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
        
        public ICollection<RoomTypeAssignment> Types { get; set; }

        public Room()
        {
            Types = new Collection<RoomTypeAssignment>();
        }
    }
}