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

            while (randDayOne != randDayTwo)
            {
                randDayTwo = rand.Next(schedule.TimeTable.Count);
            }

            var randDayOneSchedule = schedule.TimeTable[randDayOne].ToList();
            var randDayTwoSchedule = schedule.TimeTable[randDayTwo].ToList();

            schedule.TimeTable[randDayOne] = randDayTwoSchedule;
            schedule.TimeTable[randDayTwo] = randDayTwoSchedule;
        }

        private static void RemoveScheduleEntries(IList<ScheduleEntry> daySchedule, Schedule scheduleB)
        {
            foreach (var scheduleEntry in daySchedule)
            {
                foreach (var key in scheduleB.TimeTable.Keys)
                {
                    var foundSchedule = scheduleB.TimeTable[key]
                                        .Where(s => s.Course.Id == scheduleEntry.Course.Id && s.Type.Id == scheduleEntry.Type.Id)
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