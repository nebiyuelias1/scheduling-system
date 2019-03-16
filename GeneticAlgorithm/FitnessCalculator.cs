using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using Type = SchedulingSystem.Core.Models.Type;

namespace SchedulingSystem.GeneticAlgorithm
{
    public class FitnessCalculator : IFitnessCalculator
    {
        
        private readonly IUnitOfWork unitOfWork;
        private Types types;

        public FitnessCalculator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public double CalculateFitness(Schedule schedule, ICollection<CourseOffering> courseOfferings, Types types)
        {
            this.types = types;
            int conflicts = 0;
            conflicts += CountConflictsBasedOnLectureConsecutiveness(courseOfferings, schedule);
            conflicts += CountConflictsBasedOnLabConsecutiveness(courseOfferings, schedule);

            return 1.0/conflicts;
        }

        private int CountConflictsBasedOnLabConsecutiveness(ICollection<CourseOffering> courseOfferings, Schedule schedule)
        {
            int conflicts = 0;

            foreach (var c in courseOfferings)
            {
                if (c.Course.Lab >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB)
                {
                    var consecutiveFound = false;
                    foreach (var key in schedule.TimeTable.Keys)
                    {
                        var courses = schedule.TimeTable[key]
                                        .Where(s => s.Course != null)
                                        .ToList();
                        
                        if (courses.Count() > 0)
                        {
                            courses = courses.Where(s => s.CourseId == c.Course.Id && s.TypeId == types.LabType.Id)
                                        .OrderBy(s => s.Period)
                                        .ToList();

                            if (courses.Count() == GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB)
                            {
                                if ((courses.Last().Period - courses.First().Period == 2))
                                {
                                    consecutiveFound = true;
                                }
                            }

                        }
                    }
                    if (!consecutiveFound)
                        conflicts++;
                }
            }
            
            return conflicts;
        }

        private int CountConflictsBasedOnLectureConsecutiveness(ICollection<CourseOffering> courseOfferings, Schedule schedule)
        {
            int conflicts = 0;
            foreach (var c in courseOfferings)
            {
                if (c.Course.Lecture >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE)
                {
                    var consecutiveFound = false;
                    foreach (var key in schedule.TimeTable.Keys)
                    {
                        var courses = schedule.TimeTable[key]
                                        .Where(s => s.Course != null)
                                        .ToList();

                        if (courses.Count() > 0)
                        {
                            courses = courses.Where(s => s.CourseId == c.Course.Id && s.TypeId == types.LectureType.Id)
                                        .OrderBy(s => s.Period)
                                        .ToList();

                            if (courses.Count() == GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE)
                            {
                                if ((courses.Last().Period - courses.First().Period == 1))
                                {
                                    consecutiveFound = true;
                                }
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