namespace SchedulingSystem.Controllers.Resources
{
    public class ScheduleConfigurationResource
    {
        public KeyValuePairResource AdmissionLevel { get; set; }
        public KeyValuePairResource ProgramType { get; set; }
        public int NumberOfDaysPerWeek { get; set; }
        public int NumberOfPeriodsPerDay { get; set; }
    }
}