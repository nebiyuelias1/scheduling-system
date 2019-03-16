using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchedulingSystem.Core.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        
        public ICollection<Day> Days { get; set; }
        
        public AcademicSemester AcademicSemester { get; set; }
        
        public Section Section { get; set; }
        
        [NotMapped]
        public IDictionary<int, IList<ScheduleEntry>> TimeTable { get; set; }
        
        [NotMapped]
        public double Fitness { get; set; }

        

        public int AcademicSemesterId { get; set; }
        
        public int SectionId { get; set; }

        public Schedule()
        {
            Days = new Collection<Day>();
            TimeTable = new Dictionary<int, IList<ScheduleEntry>>();
        }

        public static Schedule GetNewScheduleForSection(Section section, int numberOfDaysPerWeek)
        {
            var schedule = new Schedule();
            schedule.Section = section;

            for (int i = 0; i < numberOfDaysPerWeek; i++)
            {
                schedule.TimeTable[i] = new List<ScheduleEntry>();
            }

            return schedule;
        }
    }
}