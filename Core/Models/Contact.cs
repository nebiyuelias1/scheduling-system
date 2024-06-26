using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Core.Models
{
    public class Contact
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string FatherName { get; set; }
        
        [Required]
        [StringLength(255)]
        public string GrandFatherName { get; set; }
        
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}