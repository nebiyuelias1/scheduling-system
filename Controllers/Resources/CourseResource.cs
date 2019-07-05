using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class CourseResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseCode { get; set; }
        public byte Lecture { get; set; }
        public byte Lab { get; set; }
        public byte Tutor { get; set; }
        public CurriculumResource Curriculum { get; set; }
        public int CurriculumId { get; set; }
        public byte DeliveryYear { get; set; }
        public byte DeliverySemester { get; set; }
        public int LabTypeId { get; set; }
    }
}