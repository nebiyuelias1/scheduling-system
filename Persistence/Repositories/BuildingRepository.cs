using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {
        public BuildingRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Building>> GetBuildings()
        {
            var query =  SchedulingDbContext
                        .Buildings
                        .AsQueryable();
                        
            return await query
                    .Include(b => b.Rooms)
                    .ToListAsync();
        }
    }
}