using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SchedulingSystem.Core.Models
{
    public class Instructor
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
        public int DepartmentId { get; set; }
        public bool IsActive { get; private set; }
        
        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public Instructor()
        {
            IsActive = true;
        }
    }
}