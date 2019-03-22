using System;

namespace SchedulingSystem.Controllers.Resources
{
    public class SaveScheduleConfigurationResource
    {
        public int AdmissionLevelId { get; set; }
        public int ProgramTypeId { get; set; }
        public int NumberOfDaysPerWeek { get; set; }
        public int NumberOfPeriodsPerDay { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationOfEachPeriod { get; set; }
        public bool IsThereALunchBreak { get; set; }
        public int LunchBreakDuration { get; set; }
        public int NumberOfPeriodsBeforeLunchBreak { get; set; }
    }
}