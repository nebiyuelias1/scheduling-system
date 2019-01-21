namespace SchedulingSystem.Controllers.Resources
{
    public class SaveScheduleConfigurationResource
    {
        public int AdmissionLevelId { get; set; }
        public int ProgramTypeId { get; set; }
        public int NumberOfDaysPerWeek { get; set; }
        public int NumberOfPeriodsPerDay { get; set; }
    }
}