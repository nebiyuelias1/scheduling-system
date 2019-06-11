using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        Task<Instructor> GetInstructorWithDept(int id);
        Task<QueryResult<Instructor>> GetInstructors(InstructorQuery query);
    }
}