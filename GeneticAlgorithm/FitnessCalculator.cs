using System;
using System.Collections.Generic;
using System.Linq;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.GeneticAlgorithm
{
    public static class FitnessCalculator
    {
        private readonly static byte MAX_CONSECUTIVE_LECTURE = 2;
        private readonly static byte MAX_CONSECUTIVE_LAB = 2;

        public static double CalculateFitness(this Schedule schedule, ICollection<CourseOffering> courseOfferings, ScheduleConfiguration scheduleConfiguration)
        {
            int conflicts = 0;
            conflicts += CountConflictsBasedOnLectureConsecutiveness(courseOfferings, schedule);
            conflicts += CountConflictsBasedOnLabConsecutiveness(courseOfferings, schedule);

            return 1.0/conflicts;
        }

        private static int CountConflictsBasedOnLabConsecutiveness(ICollection<CourseOffering> courseOfferings, Schedule schedule)
        {
            int conflicts = 0;
            foreach (var c in courseOfferings)
            {
                if (c.Course.Lab >= MAX_CONSECUTIVE_LAB)
                {
                    var consecutiveFound = false;
                    foreach (var key in schedule.TimeTable.Keys)
                    {
                        var courses = schedule.TimeTable[key]
                                        .Where(s => s.Course.Id == c.Course.Id && s.Type.Name == "Lab")
                                        .OrderBy(s => s.Period);

                        if (courses.Count() == MAX_CONSECUTIVE_LAB)
                        {
                            if ((courses.Last().Period - courses.First().Period == 2))
                            {
                                consecutiveFound = true;
                            }
                        }
                    }
                    if (!consecutiveFound)
                        conflicts++;
                }
            }
            
            return conflicts;
        }

        private static int CountConflictsBasedOnLectureConsecutiveness(ICollection<CourseOffering> courseOfferings, Schedule schedule)
        {
            int conflicts = 0;
            foreach (var c in courseOfferings)
            {
                if (c.Course.Lecture >= MAX_CONSECUTIVE_LECTURE)
                {
                    var consecutiveFound = false;
                    foreach (var key in schedule.TimeTable.Keys)
                    {
                        var courses = schedule.TimeTable[key]
                                        .Where(s => s.Course.Id == c.Course.Id && s.Type.Name == "Lecture")
                                        .OrderBy(s => s.Period);

                        if (courses.Count() == MAX_CONSECUTIVE_LECTURE)
                        {
                            if ((courses.Last().Period - courses.First().Period == 1))
                            {
                                consecutiveFound = true;
                            }
                        }
                    }
                    if (!consecutiveFound)
                        conflicts++;
                }
            }
            
            return conflicts;
        }
    }
}