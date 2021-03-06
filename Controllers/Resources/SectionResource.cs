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

        public CurriculumResource Curriculum { get; set; }
        
        public string Program { get; set; }

        public string AdmissionLevel { get; set; }

        public ICollection<SectionScheduleResource> Schedules { get; set; }

        public SectionResource()
        {
            Schedules = new Collection<SectionScheduleResource>();
        }
    }
}