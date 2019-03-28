using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SchedulingSystem.Core.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public ICollection<Day> Days { get; set; }

        public AcademicSemester AcademicSemester { get; set; }

        public Section Section { get; set; }

        [NotMapped]
        public IDictionary<int, IList<List<ScheduleEntry>>> TimeTable { get; set; }

        [NotMapped]
        public double Fitness { get; set; }

        public int AcademicSemesterId { get; set; }

        public int SectionId { get; set; }

        public Schedule()
        {
            Days = new Collection<Day>();
            TimeTable = new Dictionary<int, IList<List<ScheduleEntry>>>();
        }

        public static Schedule GetNewScheduleForSection(Section section, ScheduleConfiguration scheduleConfiguration)
        {
            var schedule = new Schedule();
            schedule.Section = section;

            for (int i = 0; i < scheduleConfiguration.NumberOfDaysPerWeek; i++)
            {
                schedule.TimeTable[i] = new List<List<ScheduleEntry>>();
                if (scheduleConfiguration.HasLunchBreak())
                {
                    schedule.TimeTable[i].Add(new List<ScheduleEntry>(scheduleConfiguration.HalfNumberOfPeriodsPerDay));
                    schedule.TimeTable[i].Add(new List<ScheduleEntry>(scheduleConfiguration.HalfNumberOfPeriodsPerDay));
                }
                else
                {
                    schedule.TimeTable[i].Add(new List<ScheduleEntry>());
                }
            }

            return schedule;
        }

        public int AddScheduleEntry(ScheduleEntry scheduleEntry, int day)
        {
            var earlyScheduleEntries = TimeTable[day].First();
            var sum = earlyScheduleEntries.Sum(s => s?.Duration);
            if (sum + scheduleEntry.Duration <= earlyScheduleEntries.Capacity)
            {
                scheduleEntry.Period = Convert.ToInt32(sum);
                earlyScheduleEntries.Add(scheduleEntry);
                return scheduleEntry.Duration;
            }

            var afternoonScheduleEntries = TimeTable[day].Last();
            sum = afternoonScheduleEntries.Sum(s => s?.Duration);
            if (sum + scheduleEntry.Duration <= afternoonScheduleEntries.Capacity)
            {
                scheduleEntry.Period = Convert.ToInt32(sum) + afternoonScheduleEntries.Capacity;
                afternoonScheduleEntries.Add(scheduleEntry);
                return scheduleEntry.Duration;
            }

            return 0;
        }
    }
}