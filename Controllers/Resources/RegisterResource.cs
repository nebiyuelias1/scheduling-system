using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class RegisterResource
    {
        [Required]
        [EmailAddress]
        public string Email { get;  set; }
        
        [Required]
        public string Password { get;  set; }

        [Required]
        [Compare("Password")]
        public string PasswordAgain { get; set; }
    }
}