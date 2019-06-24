using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await SchedulingDbContext
                        .Departments
                        .Include(d => d.College)
                        .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await SchedulingDbContext
                        .Departments
                        .Include(d => d.College)
                        .Include(d => d.DepartmentHead)
                            .ThenInclude(dh => dh.Contact)
                        .ToListAsync();
        }
    }
}