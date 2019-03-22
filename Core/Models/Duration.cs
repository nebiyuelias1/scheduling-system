using System;

namespace SchedulingSystem.Core.Models
{
    public class Duration
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DurationType Type { get; set; }
    }
}