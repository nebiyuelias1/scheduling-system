using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class LabTypeRepository : Repository<LabType>, ILabTypeRepository
    {
        public LabTypeRepository(SchedulingDbContext context) : base(context)
        {
        }
    }
}