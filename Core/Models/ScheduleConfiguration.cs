
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Core.Models
{
    public class ScheduleConfiguration
    {
        public AdmissionLevel AdmissionLevel { get; set; }
        public ProgramType ProgramType { get; set; }
        public int AdmissionLevelId { get; set; }
        public int ProgramTypeId { get; set; }
        public int NumberOfDaysPerWeek { get; set; }
        public int NumberOfPeriodsPerDay { get; set; }
        public ICollection<Duration> Durations { get; set; }

        public ScheduleConfiguration()
        {
            Durations = new Collection<Duration>();
        }
    }
}