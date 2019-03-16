using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchedulingSystem.Core.Models
{
    [Table("Courses")]
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseCode { get; set; }
        public int Lecture { get; set; }
        public int Lab { get; set; }
        public int Tutor { get; set; }
        public Curriculum Curriculum { get; set; }
        public int CurriculumId { get; set; }
        public byte DeliveryYear { get; set; }
        public byte DeliverySemester { get; set; }    
    }
}