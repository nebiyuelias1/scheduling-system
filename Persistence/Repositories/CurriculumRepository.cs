using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;
using SchedulingSystem.Extensions;

namespace SchedulingSystem.Persistence.Repositories
{
    public class CurriculumRepository : Repository<Curriculum>, ICurriculumRepository
    {
        public CurriculumRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<QueryResult<Curriculum>> GetCurriculums(CurriculumQuery queryObj)
        {
            var result = new QueryResult<Curriculum>();
            
            var query = SchedulingDbContext
                .Curriculums
                .AsQueryable();

            query = query.ApplyCurriculumFiltering(queryObj);
            
            result.TotalItems = await query.CountAsync();
            result.Items = await query.ToListAsync();

            return result;
        }
    }
}