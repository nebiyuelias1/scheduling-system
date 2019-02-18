using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.GeneticAlgorithm
{
    public interface IFitnessCalculator
    {
        double CalculateFitness(Schedule schedule, ICollection<CourseOffering> courseOfferings, Types types);
    }
}