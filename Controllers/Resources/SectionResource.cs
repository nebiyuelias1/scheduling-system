using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using SchedulingSystem.Core.Models;

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

        public DepartmentResource Department { get; set; }
        
        public KeyValuePairResource Program { get; set; }

        public KeyValuePairResource AdmissionLevel { get; set; }

        public ICollection<RoomSectionAssignmentResource> RoomAssignments { get; set; }

        public SectionResource()
        {
            RoomAssignments = new Collection<RoomSectionAssignmentResource>();
        }
    }
}