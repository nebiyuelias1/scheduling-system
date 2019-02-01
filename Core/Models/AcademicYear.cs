using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchedulingSystem.Core.Models
{
    [Table("AcademicYears")]
    public class AcademicYear
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string GcYear { get; set; }
        
        [Required]
        [StringLength(20)]
        public string EtYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<AcademicSemester> AcademicSemesters { get; set; }

        public AcademicYear()
        {
            AcademicSemesters = new Collection<AcademicSemester>();
        }
    }
}