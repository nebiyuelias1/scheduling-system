using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SchedulingSystem.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public ICollection<Day> Days { get; set; }

        public Schedule()
        {
            Days = new Collection<Day>();
        }
    }
}