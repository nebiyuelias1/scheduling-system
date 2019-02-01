using System.Collections.Generic;
using System.Threading.Tasks;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Core.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
         Task<Room> GetRoomWithBuildingAndType(int roomId);
         Task<IEnumerable<Room>> GetRooms(int typeId = 0);
    }
}