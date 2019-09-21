using System.Threading.Tasks;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Repositories;
using SchedulingSystem.Persistence.Repositories;

namespace SchedulingSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchedulingDbContext context;
        
        public IScheduleConfigurationRepository ScheduleConfigurations { get; private set; }
        
        public ITypeRepository Types { get; private set; }
        
        public IRoomRepository Rooms { get; private set; }
        
        public ICourseRepository Courses { get; private set; }

        public ISectionRepository Sections { get; private set; }

        public IAcademicSemesterRepository AcademicSemesters { get; private set; }

        public IWeekDayRepository WeekDays { get; private set; }
        
        public IInstructorRepository Instructors { get; private set; }

        public ICurriculumRepository Curriculums { get; private set; }

        public ICourseOfferingRepository CourseOfferings { get; private set; }
        
        public IInstructorAssignmentRepository  CourseOfferingInstructorAssignments { get; private set; }

        public IDepartmentRepository Departments { get; private set; }

        public ICollegeRepository Colleges { get; private set; }

        public IBuildingRepository Buildings { get; private set; }

        public ILabTypeRepository LabTypes { get; private set; }

        public IScheduleEntryRepository ScheduleEntries { get; private set; }
        public IScheduleRepository Schedules { get; private set; }

        public UnitOfWork(SchedulingDbContext context)
        {
            this.context = context;
            ScheduleConfigurations = new ScheduleConfigurationRepository(context);
            Types = new TypeRepository(context);
            Rooms = new RoomRepository(context);
            Courses = new CourseRepository(context);
            Sections = new SectionRepository(context);
            AcademicSemesters = new AcademicSemesterRepository(context);
            WeekDays = new WeekDayRepository(context);
            Instructors =  new InstructorRepository(context);
            Curriculums = new CurriculumRepository(context);
            CourseOfferings = new CourseOfferingRepository(context);
            CourseOfferingInstructorAssignments = new InstructorAssignmentRepository(context);
            Departments = new DepartmentRepository(context);
            Colleges = new CollegeRepository(context);
            Buildings = new BuildingRepository(context);
            LabTypes = new LabTypeRepository(context);
            ScheduleEntries = new ScheduleEntryRepository(context);
            Schedules = new ScheduleRepository(context);
        }


        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}