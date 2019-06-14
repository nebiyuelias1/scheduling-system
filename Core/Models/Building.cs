using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace SchedulingSystem.Core.Models
{
    public class Building
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        public int Number { get; set; }

        public int FloorCount { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public Building()
        {
            Rooms = new Collection<Room>();
        }
    }
}