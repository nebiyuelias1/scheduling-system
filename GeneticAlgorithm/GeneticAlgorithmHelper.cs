using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;
using SchedulingSystem.Utilities;
using Type = SchedulingSystem.Core.Models.Type;

namespace SchedulingSystem.GeneticAlgorithm
{
    public class GeneticAlgorithmHelper : IGeneticAlgorithmHelper
    {
        public Schedule InitializeScheduleForSection(Section section, ScheduleConfiguration scheduleConfiguration, Types types)
        {
            var schedule = Schedule.GetNewScheduleForSection(section, scheduleConfiguration);

            foreach (var courseOffering in section.CourseOfferings)
            {
                var lecture = courseOffering.Course.Lecture;
                var tutor = courseOffering.Course.Tutor;
                var lab = courseOffering.Course.Lab;


                while (lecture > 0)
                {
                    var randDay = Helper.GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);

                    var lectureInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == types.LectureType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                    // var lectureRoom = section
                    //                     .RoomAssignments
                    //                     .Where(r => r.TypeId == types.LectureType.Id)
                    //                     .FirstOrDefault()
                    //                     .Room;

                    var scheduleEntry = new ScheduleEntry
                    {
                        Course = courseOffering.Course,
                        CourseId = courseOffering.Course.Id,
                        Instructor = lectureInstructor,
                        // Room = lectureRoom,
                        TypeId = types.LectureType.Id,
                    };

                    if (lecture >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE)
                    {
                        scheduleEntry.Duration = GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE;
                        lecture -= schedule.AddScheduleEntry(scheduleEntry, randDay);
                    }
                    else if (lecture > 0)
                    {
                        scheduleEntry.Duration = GeneticAlgorithmConf.MAX_CONSECUTIVE_LECTURE - 1;
                        lecture -= schedule.AddScheduleEntry(scheduleEntry, randDay);
                    }
                }

                while (tutor > 0)
                {
                    var randDay = Helper.GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);

                    var tutorInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == types.TutorType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                    // var tutorRoom = section
                    //                     .RoomAssignments
                    //                     .Where(r => r.TypeId == types.TutorType.Id)
                    //                     .FirstOrDefault()
                    //                     .Room;

                    var scheduleEntry = new ScheduleEntry
                    {
                        Course = courseOffering.Course,
                        CourseId = courseOffering.Course.Id,
                        Instructor = tutorInstructor,
                        // Room = tutorRoom,
                        TypeId = types.TutorType.Id,
                        Duration = 1
                    };

                    tutor -= schedule.AddScheduleEntry(scheduleEntry, randDay);
                }

                while (lab > 0)
                {
                    var randDay = Helper.GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);

                    var labInstructor = courseOffering.Instructors
                                                    .Where(i => i.TypeId == types.LabType.Id)
                                                    .FirstOrDefault()
                                                    .Instructor;

                    // var labRoom = section
                    //                     .RoomAssignments
                    //                     .Where(r => r.TypeId == types.LabType.Id)
                    //                     .FirstOrDefault()
                    //                     .Room;

                    var scheduleEntry = new ScheduleEntry
                    {
                        Course = courseOffering.Course,
                        CourseId = courseOffering.Course.Id,
                        Instructor = labInstructor,
                        // Room = labRoom,
                        TypeId = types.LabType.Id,
                    };

                    if (lab >= GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB)
                    {
                        scheduleEntry.Duration = GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB;
                        lab -= schedule.AddScheduleEntry(scheduleEntry, randDay);
                    }
                    else if (lab >= (GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB - 1))
                    {
                        scheduleEntry.Duration = GeneticAlgorithmConf.MAX_CONSECUTIVE_LAB - 1;
                        lab -= schedule.AddScheduleEntry(scheduleEntry, randDay);
                    }
                }
            }
            return schedule;
        }
    }
}