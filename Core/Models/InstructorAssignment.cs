using System.ComponentModel.DataAnnotations.Schema;


namespace SchedulingSystem.Core.Models
{
    [Table("InstructorAssignments")]
    public class InstructorAssignment
    {
        public CourseOffering CourseOffering { get; set; }
        public Instructor Instructor { get; set; }
        public Type Type { get; set; }
        public int CourseOfferingId { get; set; }
        public int InstructorId { get; set; }
        public int TypeId { get; set; }
    }
}