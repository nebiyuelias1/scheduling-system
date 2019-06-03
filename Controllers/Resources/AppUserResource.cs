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
    }
}