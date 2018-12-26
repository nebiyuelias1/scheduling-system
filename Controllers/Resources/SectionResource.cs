using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class SectionResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public int EntranceYear { get; set; }

        public int StudentCount { get; set; }

        public int DepartmentId { get; set; }
        public int ProgramTypeId { get; set; }
        public int AdmissionLevelId { get; set; }
    }
}