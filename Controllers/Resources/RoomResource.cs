using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class RoomResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public BuildingResource Building { get; set; }
        
        public int Size { get; set; }
        
        public ICollection<KeyValuePairResource> Types { get; set; }

        public RoomResource()
        {
            Types = new Collection<KeyValuePairResource>();
        }
    }
}