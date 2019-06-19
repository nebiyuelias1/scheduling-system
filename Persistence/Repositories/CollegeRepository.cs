using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class CollegeRepository : Repository<College>, ICollegeRepository
    {
        public CollegeRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<College>> GetColleges()
        {
            return await SchedulingDbContext
                .Colleges
                .Include(c => c.CollegeDean)
                .ToListAsync();
        }
    }
}