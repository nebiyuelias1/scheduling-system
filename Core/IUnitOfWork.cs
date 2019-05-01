using System;
using System.Threading.Tasks;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Core
{
    public interface IUnitOfWork
    {
        IScheduleConfigurationRepository ScheduleConfigurations { get; }
        ITypeRepository Types { get; }
        IRoomRepository Rooms { get; }
        ICourseRepository Courses { get; }
        ISectionRepository Sections { get; }
        IAcademicSemesterRepository AcademicSemesters { get; }
        IWeekDayRepository WeekDays { get; }
        IInstructorRepository Instructors { get; }
        ICurriculumRepository Curriculums { get; }

        Task<int> CompleteAsync();
    }
}