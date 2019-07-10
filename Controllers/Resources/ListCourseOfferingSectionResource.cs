using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class ListCourseOfferingSectionResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public int EntranceYear { get; set; }

        public int StudentCount { get; set; }

        public CurriculumResource Curriculum { get; set; }
        
        public string Program { get; set; }

        public string AdmissionLevel { get; set; }
        public ICollection<CourseOfferingResource> CourseOfferings { get; set; }

        public ListCourseOfferingSectionResource()
        {
            CourseOfferings = new Collection<CourseOfferingResource>();
        }
    }
}