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
    public class GeneticAlgorithmHelper : IGeneticAlgorithmHelper
    {
        private readonly IUnitOfWork unitOfWork;

        public GeneticAlgorithmHelper(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            
        }

        public Schedule InitializeScheduleForSection(Section section, ScheduleConfiguration scheduleConfiguration, Types types)
        {
            var schedule = new Schedule();
            schedule.Section = section;

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
                        
                        var lectureInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == types.LectureType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                        var lectureRoom = section
                                            .RoomAssignments
                                            .Where(r => r.TypeId == types.LectureType.Id)
                                            .FirstOrDefault()
                                            .Room;

                        schedule.TimeTable[randDay][randPeriod].Course = courseOffering.Course;
                        schedule.TimeTable[randDay][randPeriod].CourseId = courseOffering.Course.Id;
                        schedule.TimeTable[randDay][randPeriod].Instructor = lectureInstructor;
                        schedule.TimeTable[randDay][randPeriod].Room = lectureRoom;
                        schedule.TimeTable[randDay][randPeriod].Period = randPeriod;
                        schedule.TimeTable[randDay][randPeriod].TypeId = types.LectureType.Id;

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
                        
                        var tutorInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == types.TutorType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                        var tutorRoom = section
                                            .RoomAssignments
                                            .Where(r => r.TypeId == types.TutorType.Id)
                                            .FirstOrDefault()
                                            .Room;

                        schedule.TimeTable[randDay][randPeriod].Course = courseOffering.Course;
                        schedule.TimeTable[randDay][randPeriod].CourseId = courseOffering.Course.Id;
                        schedule.TimeTable[randDay][randPeriod].Instructor = tutorInstructor;
                        schedule.TimeTable[randDay][randPeriod].Room = tutorRoom;
                        schedule.TimeTable[randDay][randPeriod].Period = randPeriod;
                        schedule.TimeTable[randDay][randPeriod].TypeId = types.TutorType.Id;

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
                        
                        var labInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == types.LabType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                        var labRoom = section
                                            .RoomAssignments
                                            .Where(r => r.TypeId == types.LabType.Id)
                                            .FirstOrDefault()
                                            .Room;

                        schedule.TimeTable[randDay][randPeriod].CourseId = courseOffering.Course.Id;
                        schedule.TimeTable[randDay][randPeriod].Instructor = labInstructor;
                        schedule.TimeTable[randDay][randPeriod].Room = labRoom;
                        schedule.TimeTable[randDay][randPeriod].Period = randPeriod;
                        schedule.TimeTable[randDay][randPeriod].TypeId = types.LabType.Id;

                        lab--;
                    }

                }
            }
            return schedule;
        }

        public async Task<ScheduleConfiguration> GetScheduleConfiguration(Section section)
        {
            return await unitOfWork.ScheduleConfigurations
                        .GetScheduleConfiguration(section.AdmissionLevelId, section.ProgramTypeId);
        }
    }
}