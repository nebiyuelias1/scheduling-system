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
        public readonly int LECTURE_ID = 1;
        public readonly int LAB_ID = 2;
        public readonly int TUTOR_ID = 3;
        
        public Schedule InitializeScheduleForSection(Section section, ScheduleConfiguration scheduleConfiguration, IList<WeekDay> weekDays, AcademicSemester academicSemester)
        {
            var schedule = new Schedule(section, scheduleConfiguration, weekDays, academicSemester);

            foreach (var courseOffering in section.CourseOfferings)
            {
                var lecture = courseOffering.Course.Lecture;
                var tutor = courseOffering.Course.Tutor;
                var lab = courseOffering.Course.Lab;


                while (lecture > 0)
                {
                    var randDay = Helper.GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);

                    var lectureInstructor = GetInstructor(courseOffering, LECTURE_ID);

                    var lectureRoom = GetRoom(courseOffering, LECTURE_ID);

                    var scheduleEntry = CreateScheduleEntry(courseOffering.Course, lectureInstructor, lectureRoom,  LECTURE_ID);
                    
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

                    var tutorInstructor = GetInstructor(courseOffering, TUTOR_ID);

                    var tutorRoom = GetRoom(courseOffering, TUTOR_ID);

                    var scheduleEntry = CreateScheduleEntry(courseOffering.Course, tutorInstructor, tutorRoom, TUTOR_ID, duration: 1);

                    tutor -= schedule.AddScheduleEntry(scheduleEntry, randDay);
                }

                while (lab > 0)
                {
                    var randDay = Helper.GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);

                    var labInstructor = GetInstructor(courseOffering, LAB_ID);

                    var labRoom =  GetRoom(courseOffering, LAB_ID);

                    var scheduleEntry = CreateScheduleEntry(courseOffering.Course, labInstructor, labRoom, LAB_ID);

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

        private ScheduleEntry CreateScheduleEntry(Course course, Instructor instructor, Room room, int typeId, int duration = 0)
        {
            return  new ScheduleEntry
            {
                Course = course,
                CourseId = course.Id,
                Instructor = instructor,
                InstructorId = instructor.Id,
                Room = room,
                RoomId = room.Id,
                TypeId = typeId,
                Duration = duration
            };
        }

        private Instructor GetInstructor(CourseOffering courseOffering, int typeId)
        {
            return courseOffering.Instructors
                .Where(i => i.TypeId == typeId)
                .FirstOrDefault()
                .Instructor;
        }

        private Room GetRoom(CourseOffering courseOffering, int typeId)
        {
            return courseOffering.Rooms
                        .Where(r => r.TypeId == typeId)
                        .FirstOrDefault()
                        .Room;
        }
    }
}