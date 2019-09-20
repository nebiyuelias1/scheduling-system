using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Controllers.Resources
{
    public class ScheduleConfigurationResource
    {
        public KeyValuePairResource AdmissionLevel { get; set; }
        public KeyValuePairResource ProgramType { get; set; }
        public ICollection<Duration> Durations { get; set; }
        public int NumberOfDaysPerWeek { get; set; }
        public int NumberOfPeriodsPerDay { get; set; }

        public ScheduleConfigurationResource()
        {
            Durations = new Collection<Duration>();
        }
    }
}