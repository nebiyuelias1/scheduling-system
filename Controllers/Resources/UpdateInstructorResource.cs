using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class UpdateInstructorResource
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

        [Required]
        public int DepartmentId { get; set; }
    }
}