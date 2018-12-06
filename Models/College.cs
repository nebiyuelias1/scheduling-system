using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Models
{
    public class College
    {
        public College()
        {
            Departments = new List<Department>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<Department> Departments { get; set; }
    }
}