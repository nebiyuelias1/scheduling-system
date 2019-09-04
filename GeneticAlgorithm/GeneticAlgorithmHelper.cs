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
        
        public Schedule InitializeScheduleForSection(Section section, ScheduleConfiguration scheduleConfiguration, IList<WeekDay> weekDays)
        {
            var schedule = new Schedule(section, scheduleConfiguration, weekDays);

            foreach (var courseOffering in section.CourseOfferings)
            {
                var lecture = courseOffering.Course.Lecture;
                var tutor = courseOffering.Course.Tutor;
                var lab = courseOffering.Course.Lab;


                while (lecture > 0)
                {
                    var randDay = Helper.GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);

                    var lectureInstructorId = GetInstructorId(courseOffering, LECTURE_ID);

                    var lectureRoomId = GetRoomId(courseOffering, LECTURE_ID);

                    var scheduleEntry = CreateScheduleEntry(courseOffering.Course.Id, lectureInstructorId, lectureRoomId,  LECTURE_ID);
                    
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

                    var tutorInstructorId = GetInstructorId(courseOffering, TUTOR_ID);

                    var tutorRoomId = GetRoomId(courseOffering, TUTOR_ID);

                    var scheduleEntry = CreateScheduleEntry(courseOffering.Course.Id, tutorInstructorId, tutorRoomId, TUTOR_ID, duration: 1);

                    tutor -= schedule.AddScheduleEntry(scheduleEntry, randDay);
                }

                while (lab > 0)
                {
                    var randDay = Helper.GetRandomInteger(scheduleConfiguration.NumberOfDaysPerWeek);

                    var labInstructorId = GetInstructorId(courseOffering, LAB_ID);

                    var labRoomId =  GetRoomId(courseOffering, LAB_ID);

                    var scheduleEntry = CreateScheduleEntry(courseOffering.Course.Id, labInstructorId, labRoomId, LAB_ID);

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

        private ScheduleEntry CreateScheduleEntry(int courseId, int instructorId, int roomId, int typeId, int duration = 0)
        {
            return  new ScheduleEntry
            {
                CourseId = courseId,
                InstructorId = instructorId,
                RoomId = roomId,
                TypeId = typeId,
                Duration = duration
            };
        }

        private int GetInstructorId(CourseOffering courseOffering, int typeId)
        {
            var id  = courseOffering.Instructors
                .Where(i => i.TypeId == typeId)
                .FirstOrDefault()
                .InstructorId;

            return (int)id;
        }

        private int GetRoomId(CourseOffering courseOffering, int typeId)
        {
            var id = courseOffering.Rooms
                        .Where(r => r.TypeId == typeId)
                        .FirstOrDefault()
                        .RoomId;

            return (int)id;
        }
    }
}