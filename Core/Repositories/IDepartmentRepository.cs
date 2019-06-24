using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> GetDepartment(int id);
        Task<IEnumerable<Department>> GetDepartments();
    }
}