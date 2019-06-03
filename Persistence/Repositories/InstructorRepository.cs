using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Instructor>> GetInstructors()
        {
            return await SchedulingDbContext
                .Instructors
                .Include(i => i.User)
                    .ThenInclude(u => u.Department)
                .ToListAsync();
        }

        public async Task<Instructor> GetInstructorWithDept(string userId)
        {
            return await SchedulingDbContext
                .Instructors
                .Include(i => i.User)
                    .ThenInclude(u => u.Department)
                .SingleOrDefaultAsync(i => i.UserId == userId);
        }
    }
}