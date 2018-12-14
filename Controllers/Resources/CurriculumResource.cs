using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class CurriculumResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nomenclature { get; set; }     

        public byte StayYear { get; set; }

        public byte StaySemester { get; set; }

        public int DepartmentId { get; set; }
    }
}