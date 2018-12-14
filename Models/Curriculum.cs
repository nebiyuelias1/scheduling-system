using System.ComponentModel.DataAnnotations;
using SchedulingSystem.Models;

namespace SchedulingSystem.Models
{
    public class Curriculum
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nomenclature { get; set; }     

        public byte StayYear { get; set; }

        public byte StaySemester { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }
    }
}