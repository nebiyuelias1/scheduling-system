using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class TypeRepository : Repository<Type>, ITypeRepository
    {

        public TypeRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<Types> GetTypes()
        {
            return new Types
            {
                LectureType = await SchedulingDbContext.Types.SingleOrDefaultAsync(t => t.Name == "Lecture"),
                TutorType = await SchedulingDbContext.Types.SingleOrDefaultAsync(t => t.Name == "Tutor"),
                LabType = await SchedulingDbContext.Types.SingleOrDefaultAsync(t => t.Name == "Lab")
            };
        }

        public async Task<Type> GetType(int typeId)
        {
            return await SchedulingDbContext
                    .Types
                    .SingleOrDefaultAsync(t => t.Id == typeId);
        }
    }
}