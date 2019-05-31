using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SchedulingSystem.Core.Models
{
    public class AppUser : IdentityUser
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
    }
}