using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.GeneticAlgorithm
{
    public interface IGeneticAlgorithmHelper
    {
        Task<Section> GetSectionWithCourseOfferings(int sectionId, int semesterId);
        void InitializePopulation(Section section);
        ICollection<Schedule> NaturalSelection();
        void CreateNextGeneration(IList<Schedule> matingPool);
    }
}