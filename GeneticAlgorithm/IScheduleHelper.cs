using System.Threading.Tasks;
using SchedulingSystem.Models;

namespace SchedulingSystem.GeneticAlgorithm
{
    public interface IScheduleHelper
    {
        Task<Schedule> InitializeScheduleForSection(Section section);
    }
}