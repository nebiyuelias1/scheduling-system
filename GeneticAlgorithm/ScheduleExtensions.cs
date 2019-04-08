using System;
using System.Collections.Generic;
using System.Linq;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.GeneticAlgorithm
{
    public static class ScheduleExtensions
    {
        public static Schedule Crossover(this Schedule scheduleA, Schedule scheduleB, ScheduleConfiguration scheduleConfiguration)
        {
            // var schedule = Schedule.GetNewScheduleForSection(scheduleA.Section, scheduleConfiguration);

            // var numberOfDays = scheduleA.TimeTable.Count;
            // for (int i = 0; i < numberOfDays; i++)
            // {
            //     if (i % 2 == 0)
            //     {
            //         schedule.TimeTable[i] = scheduleA.TimeTable[i];
            //         var daySchedule = scheduleA.TimeTable[i].First();
            //         if (scheduleA.TimeTable[i].Count > 1)
            //         {
            //             daySchedule.AddRange(scheduleA.TimeTable[i].Last());
            //         }
            //         RemoveScheduleEntries(daySchedule, scheduleB);
            //     }
            //     else
            //     {
            //         schedule.TimeTable[i] = scheduleB.TimeTable[i];
            //         var daySchedule = scheduleB.TimeTable[i].First();
            //         if (scheduleB.TimeTable[i].Count > 1)
            //         {
            //             daySchedule.AddRange(scheduleB.TimeTable[i].Last());
            //         }
            //         RemoveScheduleEntries(daySchedule, scheduleA);
            //     }
            // }

            // return schedule;
            return scheduleA;
        }

        public static void Mutate(this Schedule schedule)
        {
            var rand = new Random();

            var randDayOne = rand.Next(schedule.TimeTable.Count);
            var randDayTwo = rand.Next(schedule.TimeTable.Count);

            while (randDayOne == randDayTwo)
            {
                randDayTwo = rand.Next(schedule.TimeTable.Count);
            }

            var randDayOneSchedule = schedule.TimeTable[randDayOne].ToList();
            var randDayTwoSchedule = schedule.TimeTable[randDayTwo].ToList();

            schedule.TimeTable[randDayOne] = randDayTwoSchedule;
            schedule.TimeTable[randDayTwo] = randDayOneSchedule;
        }

        private static void RemoveScheduleEntries(IList<ScheduleEntry> daySchedule, Schedule scheduleB)
        {
            foreach (var scheduleEntry in daySchedule)
            {
                if (scheduleEntry.Course == null)
                {
                    continue;
                }

                foreach (var key in scheduleB.TimeTable.Keys)
                {
                    var earlyScheduleEntries = scheduleB.TimeTable[key].First();
                    var foundSchedule = earlyScheduleEntries
                                        .Where(s => s?.Course.CourseCode == scheduleEntry.Course.CourseCode &&
                                                s?.TypeId == scheduleEntry.TypeId &&
                                                s?.Duration == scheduleEntry.Duration)
                                        .FirstOrDefault();

                    if (foundSchedule != null)
                    {
                        foundSchedule = null;
                        break;
                    }

                    if (scheduleB.TimeTable[key].Count > 1)
                    {
                        var afternoonScheduleEntries = scheduleB.TimeTable[key].Last();
                        foundSchedule = afternoonScheduleEntries
                                        .Where(s => s?.Course.CourseCode == scheduleEntry.Course.CourseCode &&
                                                s?.TypeId == scheduleEntry.TypeId &&
                                                s?.Duration == scheduleEntry.Duration)
                                        .FirstOrDefault();

                        if (foundSchedule != null)
                        {
                            foundSchedule = null;
                            break;
                        }
                    }
                }
            }
        }
    }
}