using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public College College { get; set; }

        [ForeignKey("College")]
        public int CollegeId { get; set; }
    }
}