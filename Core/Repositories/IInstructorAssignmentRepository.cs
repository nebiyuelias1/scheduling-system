using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface IInstructorAssignmentRepository : IRepository<InstructorAssignment>
    {
        Task<InstructorAssignment> GetInstructorAssignment(int courseOfferingId, int instructorId, int typeId);
    }
}