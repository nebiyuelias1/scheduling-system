using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class CollegeResource
    {
        public CollegeResource()
        {
            Departments = new Collection<DepartmentResource>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<DepartmentResource> Departments { get; set; }
        
        public AppUserResource CollegeDean { get; set; }
    }
}