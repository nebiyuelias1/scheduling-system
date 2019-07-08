using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace SchedulingSystem.Core.Models
{
    public class CourseOffering
    {
        public int Id { get; set; }
        public Section Section { get; set; }
        public ICollection<InstructorAssignment> Instructors { get; set; }
        public ICollection<CourseOfferingRoomAssignment> Rooms { get; set; }
        public Course Course { get; set; }
        public AcademicSemester AcademicSemester { get; set; }
        public int? SectionId { get; set; }
        public int? CourseId { get; set; }
        public int? AcademicSemesterId { get; set; }

        public CourseOffering()
        {
            Instructors = new Collection<InstructorAssignment>();
            Rooms = new Collection<CourseOfferingRoomAssignment>();
        }
    }
}