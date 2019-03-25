using System;

namespace SchedulingSystem.Controllers.Resources
{
    public interface ISaveScheduleConfigurationResource
    {
        DateTime StartTime { get; set; }
        int PeriodDuration { get; set; }
        int PeriodBreakDuration { get; set; }
        bool IsThereALunchBreak { get; set; }
        int LunchBreakDuration { get; set; }
    }
}