using System.ComponentModel.DataAnnotations;


namespace SchedulingSystem.Core.Models
{
    public class ProgramType
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}