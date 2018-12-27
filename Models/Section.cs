using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SchedulingSystem.Models
{
    public class Section
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public int EntranceYear { get; set; }

        public int StudentCount { get; set; }

        public Department Department { get; set; }
        
        public ProgramType Program { get; set; }
        public AdmissionLevel AdmissionLevel { get; set; }
        public ICollection<RoomSectionAssignment> RoomAssignments { get; set; }
        public int DepartmentId { get; set; }
        public int ProgramTypeId { get; set; }
        public int AdmissionLevelId { get; set; }

        public Section()
        {
            RoomAssignments = new Collection<RoomSectionAssignment>();
        }
    }
}