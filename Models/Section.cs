using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Models
{
    public class Section
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public int EntranceYear { get; set; }

        public int StudentCount { get; set; }

        public Department Department { get; set; }
        
        public int DepartmentId { get; set; }
    }
}