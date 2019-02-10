using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;
using Type = SchedulingSystem.Core.Models.Type;

namespace SchedulingSystem.GeneticAlgorithm
{
    public class ScheduleHelper : IScheduleHelper
    {
        private readonly IUnitOfWork unitOfWork;

        public ScheduleHelper(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Schedule> InitializeScheduleForSection(Section section)
        {
            var scheduleConfiguration = await unitOfWork.ScheduleConfigurations
                                        .GetScheduleConfiguration(section.AdmissionLevelId, section.ProgramTypeId);
            
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
                    var rand = new Random();
                    var randDay = rand.Next(scheduleConfiguration.NumberOfDaysPerWeek);
                    var randPeriod = Convert.ToByte(rand.Next(scheduleConfiguration.NumberOfPeriodsPerDay));


                    if (schedule.TimeTable[randDay][randPeriod].Course == null)
                    {
                        var lectureType = await unitOfWork.Types.GetLectureType();
                        var lectureInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == lectureType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                        var lectureRoom = section
                                            .RoomAssignments
                                            .Where(r => r.TypeId == lectureType.Id)
                                            .FirstOrDefault()
                                            .Room;

                        schedule.TimeTable[randDay][randPeriod].Course = courseOffering.Course;
                        schedule.TimeTable[randDay][randPeriod].Instructor = lectureInstructor;
                        schedule.TimeTable[randDay][randPeriod].Room = lectureRoom;
                        schedule.TimeTable[randDay][randPeriod].Period = randPeriod;
                        schedule.TimeTable[randDay][randPeriod].Type = lectureType;
                        
                        lecture--;
                    }
                    
                }

                while (tutor > 0)
                {
                    
                    
                    var rand = new Random();
                    var randDay = rand.Next(scheduleConfiguration.NumberOfDaysPerWeek);
                    var randPeriod = Convert.ToByte(rand.Next(scheduleConfiguration.NumberOfPeriodsPerDay));


                    if (schedule.TimeTable[randDay][randPeriod].Course == null)
                    {
                        var tutorType = await unitOfWork.Types.GetTutorType();
                        var tutorInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == tutorType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                        var tutorRoom = section
                                            .RoomAssignments
                                            .Where(r => r.TypeId == tutorType.Id)
                                            .FirstOrDefault()
                                            .Room;

                        schedule.TimeTable[randDay][randPeriod].Course = courseOffering.Course;
                        schedule.TimeTable[randDay][randPeriod].Instructor = tutorInstructor;
                        schedule.TimeTable[randDay][randPeriod].Room = tutorRoom;
                        schedule.TimeTable[randDay][randPeriod].Period = randPeriod;
                        schedule.TimeTable[randDay][randPeriod].Type = tutorType;
                        
                        tutor--;
                    }
                    
                }

                while (lab > 0)
                {
                    
                    
                    var rand = new Random();
                    var randDay = rand.Next(scheduleConfiguration.NumberOfDaysPerWeek);
                    var randPeriod = Convert.ToByte(rand.Next(scheduleConfiguration.NumberOfPeriodsPerDay));


                    if (schedule.TimeTable[randDay][randPeriod].Course == null)
                    {
                        var labType = await unitOfWork.Types.GetLabType();
                        var labInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == labType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                        var labRoom = section
                                            .RoomAssignments
                                            .Where(r => r.TypeId == labType.Id)
                                            .FirstOrDefault()
                                            .Room;

                        schedule.TimeTable[randDay][randPeriod].Course = courseOffering.Course;
                        schedule.TimeTable[randDay][randPeriod].Instructor = labInstructor;
                        schedule.TimeTable[randDay][randPeriod].Room = labRoom;
                        schedule.TimeTable[randDay][randPeriod].Period = randPeriod;
                        schedule.TimeTable[randDay][randPeriod].Type = labType;
                        
                        lab--;
                    }
                    
                }
            }

            schedule.CalculateFitness(section.CourseOfferings);
            return schedule;
        }
    }
}