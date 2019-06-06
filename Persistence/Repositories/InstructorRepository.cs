using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;
using SchedulingSystem.Extensions;

namespace SchedulingSystem.Persistence.Repositories
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<QueryResult<Instructor>> GetInstructors(InstructorQuery queryObj)
        {
            var result = new QueryResult<Instructor>();
            
            var query = SchedulingDbContext
                .Instructors
                .Include(i => i.User)
                    .ThenInclude(u => u.Department)
                .AsQueryable();

            query = query.ApplyFiltering(queryObj);
            
            result.TotalItems = await query.CountAsync();
            result.Items = await query.ToListAsync();

            return result;
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