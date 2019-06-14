using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface IBuildingRepository : IRepository<Building>
    {
         Task<IEnumerable<Building>> GetBuildings();
    }
}