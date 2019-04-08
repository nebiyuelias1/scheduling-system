using System;
using SchedulingSystem.Core;

namespace SchedulingSystem.Utilities
{
    public class Helper : IHelper
    {
        public int CalculateCurrentYearOfSection(int ethiopianYear, int entranceYear)
        {
            return (ethiopianYear - entranceYear) + 1;
        }

        public static int GetRandomInteger(int upperLimit)
        {
            return new Random().Next(upperLimit);
        }
    }
}