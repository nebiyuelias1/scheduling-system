namespace SchedulingSystem.Models
{
    public class ScheduleConfiguration
    {
        public AdmissionLevel AdmissionLevel { get; set; }
        public ProgramType ProgramType { get; set; }
        public int AdmissionLevelId { get; set; }
        public int ProgramTypeId { get; set; }
        public int NumberOfDaysPerWeek { get; set; }
        public int NumberOfPeriodsPerDay { get; set; }
    }
}