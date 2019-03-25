
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SchedulingSystem.Controllers.Resources;

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

        internal void CreateDurations(ISaveScheduleConfigurationResource resource)
        {
            var startTime = resource.StartTime;
            for (int i = 0; i < NumberOfPeriodsPerDay / 2; i++)
            {
                var classDuration = new Duration
                {
                    StartTime = startTime,
                    EndTime = startTime.AddMinutes(resource.PeriodDuration),
                    Type = DurationType.Class
                };

                startTime = startTime.AddMinutes(resource.PeriodDuration);
                Durations.Add(classDuration);
                
                if (resource.IsThereALunchBreak && i == (NumberOfPeriodsPerDay / 2) -1)
                {
                    break;
                }
                var periodBreakDuration = new Duration
                {
                    StartTime = startTime,
                    EndTime = startTime.AddMinutes(resource.PeriodBreakDuration),
                    Type = DurationType.InBetweenClassBreak
                };
                startTime = startTime.AddMinutes(resource.PeriodBreakDuration);
                Durations.Add(periodBreakDuration);                
            }

            if (resource.IsThereALunchBreak)
            {
                var lunchBreakDuration = new Duration
                {
                    StartTime = startTime,
                    EndTime = startTime.AddMinutes(resource.LunchBreakDuration),
                    Type = DurationType.LunchBreak
                };
                startTime = startTime.AddMinutes(resource.LunchBreakDuration);
                Durations.Add(lunchBreakDuration);
            }
            for (int i = NumberOfPeriodsPerDay/2; i < NumberOfPeriodsPerDay; i++)
            {
                var classDuration = new Duration
                {
                    StartTime = startTime,
                    EndTime = startTime.AddMinutes(resource.PeriodDuration),
                    Type = DurationType.Class
                };
                startTime = startTime.AddMinutes(resource.PeriodDuration);
                Durations.Add(classDuration);

                if (i == NumberOfPeriodsPerDay - 1)
                    break;
                    
                var periodBreakDuration = new Duration
                {
                    StartTime = startTime,
                    EndTime = startTime.AddMinutes(resource.PeriodBreakDuration),
                    Type = DurationType.InBetweenClassBreak
                };
                startTime = startTime.AddMinutes(resource.PeriodBreakDuration);
                Durations.Add(periodBreakDuration);                
            }
        }
    }
}