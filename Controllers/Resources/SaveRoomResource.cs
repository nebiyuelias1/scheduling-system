using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class SaveRoomResource
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int BuildingId { get; set; }
        public int Size { get; set; }
        public int Floor { get; set; }
        public ICollection<int> Types { get; set; }

        public SaveRoomResource()
        {
            Types = new Collection<int>();
        }
    }
}