using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Models
{
    public class AdmissionLevel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}