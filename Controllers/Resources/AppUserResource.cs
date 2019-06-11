using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class AppUserResource
    {
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string FatherName { get; set; }

        [Required]
        [StringLength(255)]
        public string GrandFatherName { get; set; }
        
        public DepartmentResource Department { get; set; }
        public int DepartmentId { get; set; }
        public string Email { get; set; }
    }
}