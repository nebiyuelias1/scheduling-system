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
        public Schedule InitializeScheduleForSection(Section section, ScheduleConfiguration scheduleConfiguration, Types types)
        {
            var schedule = Schedule.GetNewScheduleForSection(section, scheduleConfiguration.NumberOfDaysPerWeek);

            foreach (var courseOffering in section.CourseOfferings)
            {
                var lecture = courseOffering.Course.Lecture;
                var tutor = courseOffering.Course.Tutor;
                var lab = courseOffering.Course.Lab;


                while (lecture > 0)
                {
                    var randDay = GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);
                    var durationSum = 0;
                    var sum = schedule.TimeTable[randDay].Sum(s => s?.Duration);
                    if (sum != null)
                    {
                        durationSum = Convert.ToInt32(sum);
                    }

                    var lectureInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == types.LectureType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                    var lectureRoom = section
                                        .RoomAssignments
                                        .Where(r => r.TypeId == types.LectureType.Id)
                                        .FirstOrDefault()
                                        .Room;

                    if (lecture >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE &&
                        durationSum <= (scheduleConfiguration.NumberOfPeriodsPerDay - GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE))
                    {


                        var scheduleEntry = new ScheduleEntry
                        {
                            Course = courseOffering.Course,
                            CourseId = courseOffering.Course.Id,
                            Instructor = lectureInstructor,
                            Room = lectureRoom,
                            Period = durationSum + 1,
                            TypeId = types.LectureType.Id,
                            Duration = GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE
                        };

                        schedule.TimeTable[randDay].Add(scheduleEntry);
                        lecture -= GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE;
                    }
                    else if (durationSum < scheduleConfiguration.NumberOfPeriodsPerDay)
                    {
                        var scheduleEntry = new ScheduleEntry
                        {
                            Course = courseOffering.Course,
                            CourseId = courseOffering.Course.Id,
                            Instructor = lectureInstructor,
                            Room = lectureRoom,
                            Period = durationSum + 1,
                            TypeId = types.LectureType.Id,
                            Duration = 1
                        };

                        schedule.TimeTable[randDay].Add(scheduleEntry);
                        lecture--;
                    }
                }

                while (tutor > 0)
                {
                    var randDay = GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);
                    var durationSum = 0;
                    var sum = schedule.TimeTable[randDay].Sum(s => s?.Duration);
                    if (sum != null)
                    {
                        durationSum = Convert.ToInt32(sum);
                    }

                    var tutorInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == types.TutorType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                    var tutorRoom = section
                                        .RoomAssignments
                                        .Where(r => r.TypeId == types.TutorType.Id)
                                        .FirstOrDefault()
                                        .Room;

                    if (durationSum < scheduleConfiguration.NumberOfPeriodsPerDay)
                    {
                        var scheduleEntry = new ScheduleEntry
                        {
                            Course = courseOffering.Course,
                            CourseId = courseOffering.Course.Id,
                            Instructor = tutorInstructor,
                            Room = tutorRoom,
                            Period = durationSum + 1,
                            TypeId = types.TutorType.Id,
                            Duration = 1
                        };

                        schedule.TimeTable[randDay].Add(scheduleEntry);
                        tutor--;
                    }
                }

                while (lab > 0)
                {
                    var randDay = GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);
                    var durationSum = 0;
                    var sum = schedule.TimeTable[randDay].Sum(s => s?.Duration);
                    if (sum != null)
                    {
                        durationSum = Convert.ToInt32(sum);
                    }

                    var labInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == types.LabType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                    var labRoom = section
                                        .RoomAssignments
                                        .Where(r => r.TypeId == types.LabType.Id)
                                        .FirstOrDefault()
                                        .Room;

                    if (lab >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB &&
                        durationSum <= (scheduleConfiguration.NumberOfPeriodsPerDay - GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB))
                    {
                        var scheduleEntry = new ScheduleEntry
                        {
                            Course = courseOffering.Course,
                            CourseId = courseOffering.Course.Id,
                            Instructor = labInstructor,
                            Room = labRoom,
                            Period = durationSum + 1,
                            TypeId = types.LabType.Id,
                            Duration = GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB
                        };

                        schedule.TimeTable[randDay].Add(scheduleEntry);
                        lab -= GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB;
                    }
                    else if (lab >= (GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB - 1) &&
                        durationSum <= (scheduleConfiguration.NumberOfPeriodsPerDay - GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB - 1))
                    {
                        var scheduleEntry = new ScheduleEntry
                        {
                            Course = courseOffering.Course,
                            CourseId = courseOffering.Course.Id,
                            Instructor = labInstructor,
                            Room = labRoom,
                            Period = durationSum + 1,
                            TypeId = types.LabType.Id,
                            Duration = GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB - 1
                        };

                        schedule.TimeTable[randDay].Add(scheduleEntry);
                        lab -= GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB - 1;
                    }
                }
            }
            return schedule;
        }

        private int GetRandomInteger(int upperLimit)
        {
            return new Random().Next(upperLimit);
        }
    }
}