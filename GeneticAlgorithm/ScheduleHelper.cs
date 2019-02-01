using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;
using Type = SchedulingSystem.Core.Models.Type;

namespace SchedulingSystem.GeneticAlgorithm
{
    public class ScheduleHelper : IScheduleHelper
    {
        private readonly SchedulingDbContext context;
        public ScheduleHelper(SchedulingDbContext context)
        {
            this.context = context;
        }

        private async Task<Type> GetLectureType()
        {
            return await context.Types.Where(t => t.Name == "Lecture")
                        .FirstOrDefaultAsync();
        }

        private async Task<Type> GetTutorType()
        {
            return await context.Types.Where(t => t.Name == "Tutor")
                        .FirstOrDefaultAsync();
        }

        private async Task<Type> GetLabType()
        {
            return await context.Types.Where(t => t.Name == "Lab")
                        .FirstOrDefaultAsync();
        }
        public async Task<Schedule> InitializeScheduleForSection(Section section)
        {
            var scheduleConfiguration = await context
                                        .ScheduleConfigurations
                                        .SingleOrDefaultAsync(s => s.AdmissionLevelId == section.AdmissionLevelId && s.ProgramTypeId == section.ProgramTypeId);
            
            var schedule = new Schedule();

            for (int i = 0; i < scheduleConfiguration.NumberOfDaysPerWeek; i++)
            {
                var periods = new List<ScheduleEntry>(scheduleConfiguration.NumberOfPeriodsPerDay);

                for (int j = 0; j < scheduleConfiguration.NumberOfPeriodsPerDay; j++)
                {
                    periods.Add(new ScheduleEntry());
                }
                schedule.TimeTable[i] = periods;
            }

            foreach (var courseOffering in section.CourseOfferings)
            {
                var lecture = courseOffering.Course.Lecture;
                var tutor = courseOffering.Course.Tutor;
                var lab = courseOffering.Course.Lab;


                while (lecture > 0)
                {
                    var lectureType = await GetLectureType();
                    var lectureInstructor = courseOffering.Instructors
                                                .Where(i => i.TypeId == lectureType.Id)
                                                .FirstOrDefault()
                                                .Instructor;

                    var lectureRoom = section
                                        .RoomAssignments
                                        .Where(r => r.TypeId == lectureType.Id)
                                        .FirstOrDefault()
                                        .Room;
                    
                    var rand = new Random();
                    var randDay = rand.Next(scheduleConfiguration.NumberOfDaysPerWeek);
                    var randPeriod = Convert.ToByte(rand.Next(scheduleConfiguration.NumberOfPeriodsPerDay));


                    if (schedule.TimeTable[randDay][randPeriod].Course == null)
                    {
                        new ScheduleEntry
                        {
                            Course = courseOffering.Course,
                            Instructor = lectureInstructor,
                            Room = lectureRoom,
                            Period = randPeriod,
                            Type = lectureType
                        };
                        
                    }
                    
                    lecture--;
                }

                while (tutor > 0)
                {
                    var tutorType = await GetTutorType();
                    var tutorInstructor = courseOffering.Instructors
                                                .Where(i => i.TypeId == tutorType.Id)
                                                .FirstOrDefault()
                                                .Instructor;

                    var tutorRoom = section
                                        .RoomAssignments
                                        .Where(r => r.TypeId == tutorType.Id)
                                        .FirstOrDefault()
                                        .Room;
                    
                    var rand = new Random();
                    var randDay = rand.Next(scheduleConfiguration.NumberOfDaysPerWeek);
                    var randPeriod = Convert.ToByte(rand.Next(scheduleConfiguration.NumberOfPeriodsPerDay));


                    if (schedule.TimeTable[randDay][randPeriod].Course == null)
                    {
                        new ScheduleEntry
                        {
                            Course = courseOffering.Course,
                            Instructor = tutorInstructor,
                            Room = tutorRoom,
                            Period = randPeriod,
                            Type = tutorType
                        };
                        
                    }
                    
                    tutor--;
                }

                while (lab > 0)
                {
                    var labType = await GetLabType();
                    var labInstructor = courseOffering.Instructors
                                                .Where(i => i.TypeId == labType.Id)
                                                .FirstOrDefault()
                                                .Instructor;

                    var labRoom = section
                                        .RoomAssignments
                                        .Where(r => r.TypeId == labType.Id)
                                        .FirstOrDefault()
                                        .Room;
                    
                    var rand = new Random();
                    var randDay = rand.Next(scheduleConfiguration.NumberOfDaysPerWeek);
                    var randPeriod = Convert.ToByte(rand.Next(scheduleConfiguration.NumberOfPeriodsPerDay));


                    if (schedule.TimeTable[randDay][randPeriod].Course == null)
                    {
                        new ScheduleEntry
                        {
                            Course = courseOffering.Course,
                            Instructor = labInstructor,
                            Room = labRoom,
                            Period = randPeriod,
                            Type = labType
                        };
                        
                    }
                    
                    lab--;
                }
            }

            return schedule;
        }
    }
}