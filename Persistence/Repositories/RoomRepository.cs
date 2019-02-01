using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;

namespace SchedulingSystem.Persistence.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Room>> GetRooms(int typeId = 0)
        {
            var query = SchedulingDbContext.Rooms
                .Include(r => r.Building)
                .Include(r => r.Types)
                    .ThenInclude(t => t.Type)
                .AsQueryable();

            if (typeId != 0)
            {
                query = query
                        .Where(r => r.Types.Select(t => t.TypeId).Contains(typeId));
            }

            return await query.ToListAsync();
        }

        public async Task<Room> GetRoomWithBuildingAndType(int roomId)
        {
            return await SchedulingDbContext.Rooms
                    .Include(r => r.Building)
                    .Include(r => r.Types)
                        .ThenInclude(t => t.Type)
                    .SingleOrDefaultAsync(r => r.Id == roomId);
        }
    }
}