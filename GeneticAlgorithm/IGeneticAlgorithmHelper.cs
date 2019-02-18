using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.GeneticAlgorithm
{
    public interface IGeneticAlgorithmHelper
    {
        Schedule InitializeScheduleForSection(Section section, ScheduleConfiguration scheduleConfiguration, Types types);
    }
}