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

        public UnitOfWork(SchedulingDbContext context)
        {
            this.context = context;
            ScheduleConfigurations = new ScheduleConfigurationRepository(context);
            Types = new TypeRepository(context);
            Rooms = new RoomRepository(context);
        }


        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}