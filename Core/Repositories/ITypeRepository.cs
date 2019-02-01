using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface ITypeRepository : IRepository<Type>
    {
        Task<Type> GetLectureType();
        Task<Type> GetTutorType();
        Task<Type> GetLabType();
    }
}