using System.Collections.Generic;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Controllers.Resources
{
    public class ScheduleResource
    {
        public int Id { get; set; }
        
        public IDictionary<int, IList<ScheduleEntry>> TimeTable { get; set; }
        
        public double Fitness { get; set; }

    }
}