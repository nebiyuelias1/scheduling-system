using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Controllers.Resources
{
    public class CourseOfferingResource
    {
        public int Id { get; set; }
        public SectionResource Section { get; set; }
        public SaveCourseResource Course { get; set; }
        public AcademicSemesterResource AcademicSemester { get; set; }

        public ICollection<InstructorAssignmentResource> Instructors { get; set; }
        public ICollection<CourseOfferingRoomAssignmentResource> Rooms { get; set; }

        public CourseOfferingResource()
        {
            Instructors = new Collection<InstructorAssignmentResource>();
        }

    }
}