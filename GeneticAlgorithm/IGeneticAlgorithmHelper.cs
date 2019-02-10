using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.GeneticAlgorithm
{
    public interface IGeneticAlgorithmHelper
    {
        void InitializePopulation(Section section);
        ICollection<Schedule> NaturalSelection();
        void CreateNextGeneration(IList<Schedule> matingPool);
        Schedule FindBestSchedule();
    }
}