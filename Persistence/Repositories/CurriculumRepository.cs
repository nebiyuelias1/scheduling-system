using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class CurriculumRepository : Repository<Curriculum>, ICurriculumRepository
    {
        public CurriculumRepository(SchedulingDbContext context) : base(context)
        {
        }
    }
}