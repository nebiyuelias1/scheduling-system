using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/rooms")]
    public class RoomsController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IMapper mapper;

        public RoomsController(SchedulingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveRoomResource roomResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = mapper.Map<SaveRoomResource, Room>(roomResource);

            context.Rooms.Add(room);
            await context.SaveChangesAsync();

            room =  await context.Rooms
                    .Include(r => r.Building)
                    .Include(r => r.Types)
                        .ThenInclude(t => t.RoomType)
                    .SingleOrDefaultAsync(r => r.Id == room.Id);

            var result = mapper.Map<Room, RoomResource>(room);

            return Ok(result);
        }

        [HttpGet()]
        public async  Task<IActionResult> GetRoomsBasedOnType([FromQuery] int typeId)
        {
            var rooms = await context.Rooms
                .Include(r => r.Building)
                .Include(r => r.Types)
                    .ThenInclude(t => t.RoomType)
                .Where(r => r.Types.Select(t => t.RoomTypeId).Contains(typeId))
                .ToListAsync();

            var result = mapper.Map<IList<Room>, IList<RoomResource>>(rooms);
            
            return Ok(result);
        }
    }
}