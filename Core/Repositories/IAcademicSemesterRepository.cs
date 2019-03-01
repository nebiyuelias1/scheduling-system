using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface IAcademicSemesterRepository : IRepository<AcademicSemester>
    {
        Task<AcademicSemester> GetCurrentAcademicSemester();
        Task<AcademicSemester> GetAcademicSemester(int id);
    }
}