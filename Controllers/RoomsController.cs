using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core.Models;
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
                        .ThenInclude(t => t.Type)
                    .SingleOrDefaultAsync(r => r.Id == room.Id);

            var result = mapper.Map<Room, RoomResource>(room);

            return Ok(result);
        }

        [HttpGet("{typeId}")]
        public async  Task<IActionResult> GetRoomsBasedOnType([FromRoute] int typeId)
        {
            var rooms = await context.Rooms
                .Include(r => r.Building)
                .Include(r => r.Types)
                    .ThenInclude(t => t.Type)
                .Where(r => r.Types.Select(t => t.TypeId).Contains(typeId))
                .ToListAsync();

            var result = mapper.Map<IList<Room>, IList<RoomResource>>(rooms);
            
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await context.Rooms
                .Include(r => r.Building)
                .Include(r => r.Types)
                    .ThenInclude(t => t.Type)
                .ToListAsync();

            var result = mapper.Map<IList<Room>, IList<RoomResource>>(rooms);
            
            return Ok(result);
        }
    }
}