using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface ICollegeRepository : IRepository<College>
    {
        Task<IEnumerable<College>> GetColleges();
    }
}