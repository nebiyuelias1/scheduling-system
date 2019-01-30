using System.Threading.Tasks;
using SchedulingSystem.Models;

namespace SchedulingSystem.Core
{
    public interface IGeneticAlgorithm
    {
        Task<Schedule> GenerateScheduleForSection(int sectionId);
    }
}