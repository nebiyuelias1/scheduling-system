using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;
using SchedulingSystem.Extensions;

namespace SchedulingSystem.Persistence.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(SchedulingDbContext context) : base(context)
        {
        }

        public async Task<QueryResult<Room>> GetRooms(RoomQuery queryObj)
        {
            var result = new QueryResult<Room>();

            var query = SchedulingDbContext.Rooms
                .Include(r => r.Building)
                .Include(r => r.Types)
                    .ThenInclude(t => t.Type)
                .AsQueryable();

            query = query.ApplyRoomFilter(queryObj);

            result.TotalItems = await query.CountAsync();
            result.Items = await query.ToListAsync();

            return result;
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