using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Models
{
    public class Building
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        
        public int Number { get; set; }
    }
}