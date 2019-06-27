using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace SchedulingSystem.Core.Models
{
    public class Section
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public int EntranceYear { get; set; }

        public int StudentCount { get; set; }

        public Curriculum Curriculum { get; set; }
        
        public ProgramType Program { get; set; }

        public AdmissionLevel AdmissionLevel { get; set; }

        public ICollection<SectionRoomAssignment> RoomAssignments { get; set; }
        
        public ICollection<CourseOffering> CourseOfferings { get; set; }

        public bool IsActive { get; private set; }

        public int CurriculumId { get; set; }

        public int ProgramTypeId { get; set; }

        public int AdmissionLevelId { get; set; }

        public Section()
        {
            RoomAssignments = new Collection<SectionRoomAssignment>();
            CourseOfferings = new Collection<CourseOffering>();
            IsActive = true;
        }

        public void MakeInactive()
        {
            if (IsActive)
                IsActive = false;
        }
    }
}