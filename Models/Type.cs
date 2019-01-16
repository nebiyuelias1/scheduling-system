using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingSystem.Models
{
    public class Type
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}