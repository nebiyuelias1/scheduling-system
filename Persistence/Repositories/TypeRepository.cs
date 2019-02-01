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

        public async Task<Type> GetLabType()
        {
            return await SchedulingDbContext.Types.SingleOrDefaultAsync(t => t.Name == "Lab");
        }

        public async Task<Type> GetLectureType()
        {
            return await SchedulingDbContext.Types.SingleOrDefaultAsync(t => t.Name == "Lecture");
        }

        public async Task<Type> GetTutorType()
        {
            return await SchedulingDbContext.Types.SingleOrDefaultAsync(t => t.Name == "Tutor");
        }
    }
}