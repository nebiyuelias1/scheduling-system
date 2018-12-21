using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class BuildingResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        public int Number { get; set; }
    }
}