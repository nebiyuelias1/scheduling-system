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

            return 1.0/(conflicts + 1);
        }

        private int CountConflictsBasedOnLabConsecutiveness(ICollection<CourseOffering> courseOfferings, Schedule schedule)
        {
            int conflicts = 0;

            // foreach (var c in courseOfferings)
            // {
            //     if (c.Course.Lab >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB)
            //     {
            //         var consecutiveFound = false;
            //         foreach (var key in schedule.TimeTable.Keys)
            //         {
            //             var courses = schedule.TimeTable[key]
            //                             .Where(s => s.Course != null)
            //                             .ToList();
                        
            //             if (courses.Count() > 0)
            //             {
            //                 consecutiveFound = courses
            //                                     .Any(s => s.CourseId == c.Course.Id && s.TypeId == types.LabType.Id && s.Duration >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB);
            //             }
            //         }
            //         if (!consecutiveFound)
            //             conflicts++;
            //     }
            // }
            
            return conflicts;
        }

        private int CountConflictsBasedOnLectureConsecutiveness(ICollection<CourseOffering> courseOfferings, Schedule schedule)
        {
            int conflicts = 0;
            // foreach (var c in courseOfferings)
            // {
            //     if (c.Course.Lecture >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE)
            //     {
            //         var consecutiveFound = false;
            //         foreach (var key in schedule.TimeTable.Keys)
            //         {
            //             var courses = schedule.TimeTable[key]
            //                             .Where(s => s.Course != null)
            //                             .ToList();

            //             if (courses.Count() > 0)
            //             {
            //                 consecutiveFound = courses
            //                             .Any(s => s.CourseId == c.Course.Id && s.TypeId == types.LectureType.Id && s.Duration >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE);
            //             }
            //         }
                    
            //         if (!consecutiveFound)
            //             conflicts++;
            //     }
            // }
            
            return conflicts;
        }
    }
}