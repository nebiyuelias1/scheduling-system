using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class RegisterResource
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

        [Required]
        [EmailAddress]
        public string Email { get;  set; }
        
        [Required]
        public string Password { get;  set; }

        [Required]
        [Compare("Password")]
        public string PasswordAgain { get; set; }
        
        [Required]
        public string Role { get; set; }

        public int? DepartmentId { get; set; }
    }
}