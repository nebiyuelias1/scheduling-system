using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using SchedulingSystem.Utilities;

namespace SchedulingSystem.Core.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public AcademicSemester AcademicSemester { get; set; }

        public Section Section { get; set; }
        
        public IList<DaySchedule> TimeTable { get; set; }

        [NotMapped]
        public double Fitness { get; set; }

        public int AcademicSemesterId { get; set; }

        public int SectionId { get; set; }

        public Schedule(Section section, ScheduleConfiguration scheduleConfiguration, IList<WeekDay> weekDays)
            : this()
        {
            this.Section = section;
            for (int i = 0; i < scheduleConfiguration.NumberOfDaysPerWeek; i++)
            {
                var daySchedule = new DaySchedule
                {
                    WeekDayId = weekDays[i].Id
                };

                if (scheduleConfiguration.HasLunchBreak())
                {
                    daySchedule.DaySessions.Add(
                        new DaySession(scheduleConfiguration.HalfNumberOfPeriodsPerDay));

                    daySchedule.DaySessions.Add(
                        new DaySession(scheduleConfiguration.HalfNumberOfPeriodsPerDay));
                }
                else
                {
                    daySchedule.DaySessions.Add(new DaySession(scheduleConfiguration.NumberOfPeriodsPerDay));
                }

                this.TimeTable.Add(daySchedule);
            }
        }
        public Schedule()
        {
            TimeTable = new Collection<DaySchedule>();
        }

        public int AddScheduleEntry(ScheduleEntry scheduleEntry, int day)
        {
            if (TimeTable[day].DaySessions.Count > 1)
            {
                var earlyDaySession = TimeTable[day].DaySessions.First();
                var earlySum = earlyDaySession.ScheduleEntries.Sum(s => s?.Duration);

                if (earlySum + scheduleEntry.Duration <= earlyDaySession.ScheduleEntries.Capacity)
                {
                    scheduleEntry.Period = Convert.ToInt32(earlySum);
                    earlyDaySession.ScheduleEntries.Add(scheduleEntry);
                    return scheduleEntry.Duration;
                }
            }

            var afternoonScheduleEntries = TimeTable[day].DaySessions.Last();
            var afternoonSum = afternoonScheduleEntries.ScheduleEntries.Sum(s => s?.Duration);
            if (afternoonSum + scheduleEntry.Duration <= afternoonScheduleEntries.ScheduleEntries.Capacity)
            {
                scheduleEntry.Period = Convert.ToInt32(afternoonSum) + afternoonScheduleEntries.ScheduleEntries.Capacity;
                afternoonScheduleEntries.ScheduleEntries.Add(scheduleEntry);
                return scheduleEntry.Duration;
            }

            return 0;
        }
    }
}