using SchedulingSystem.Core;

namespace SchedulingSystem.Utilities
{
    public class Helper : IHelper
    {
        public int CalculateCurrentYearOfSection(int ethiopianYear, int entranceYear)
        {
            return (ethiopianYear - entranceYear) + 1;
        }
    }
}