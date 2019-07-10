using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Controllers.Resources
{
    public class ListCourseOfferingResource
    {
        public ICollection<ListCourseOfferingSectionResource> Sections { get; set; }

        public ListCourseOfferingResource()
        {
            Sections = new Collection<ListCourseOfferingSectionResource>();
        }
    }
}