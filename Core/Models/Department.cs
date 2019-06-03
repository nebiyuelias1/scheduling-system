using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchedulingSystem.Core.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public College College { get; set; }

        [ForeignKey("College")]
        public int CollegeId { get; set; }

        public ICollection<AppUser> Users { get; set; }

        public Department()
        {
            Users = new Collection<AppUser>();
        }
    }
}