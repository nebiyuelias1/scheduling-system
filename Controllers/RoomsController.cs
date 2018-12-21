using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create([FromBody] RoomResource roomResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = mapper.Map<RoomResource, Room>(roomResource);

            context.Rooms.Add(room);
            await context.SaveChangesAsync();

            roomResource = mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);
        }
    }
}