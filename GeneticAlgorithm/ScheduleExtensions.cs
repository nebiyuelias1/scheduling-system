using System;
using System.Collections.Generic;
using System.Linq;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.GeneticAlgorithm
{
    public static class ScheduleExtensions
    {
        public static Schedule Crossover(this Schedule scheduleA, Schedule scheduleB)
        {
            var schedule = new Schedule();
            schedule.Section = scheduleA.Section;
            
            var numberOfDays = scheduleA.TimeTable.Count;
            for (int i = 0; i < numberOfDays; i++)
            {
                if (i % 2 == 0)
                {
                    schedule.TimeTable.Add(i, scheduleA.TimeTable[i]);
                    RemoveScheduleEntries(scheduleA.TimeTable[i], scheduleB);
                }
                else
                {
                    schedule.TimeTable.Add(i, scheduleB.TimeTable[i]);
                    RemoveScheduleEntries(scheduleB.TimeTable[i], scheduleA);
                }
            }

            return schedule;
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
                if (scheduleEntry.Course != null)
                {
                    foreach (var key in scheduleB.TimeTable.Keys)
                    {
                        
                        var foundSchedule = scheduleB.TimeTable[key]
                                        .Where(s => s.Course != null)
                                        .ToList()
                                        .Where(s => s.Course.CourseCode == scheduleEntry.Course.CourseCode && s.TypeId == scheduleEntry.TypeId)
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