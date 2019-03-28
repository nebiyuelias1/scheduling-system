using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core
{
    public interface IGeneticAlgorithm
    {
        Task<Schedule> GenerateScheduleForSection(int sectionId, ScheduleConfiguration scheduleConfiguration);
    }
}