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

        public UnitOfWork(SchedulingDbContext context)
        {
            this.context = context;
            ScheduleConfigurations = new ScheduleConfigurationRepository(context);
            Types = new TypeRepository(context);
            Rooms = new RoomRepository(context);
            Courses = new CourseRepository(context);
            Sections = new SectionRepository(context);
            AcademicSemesters = new AcademicSemesterRepository(context);
        }


        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}