using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.GeneticAlgorithm
{
    public interface IScheduleHelper
    {
        Task<Schedule> InitializeScheduleForSection(Section section);
    }
}