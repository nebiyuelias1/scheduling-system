using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class InstructorResource
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

        public int DepartmentId { get; set; }
    }
}