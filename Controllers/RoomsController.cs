using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/rooms")]
    public class RoomsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RoomsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveRoomResource roomResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = mapper.Map<SaveRoomResource, Room>(roomResource);

            unitOfWork.Rooms.Add(room);
            await unitOfWork.CompleteAsync();

            room = await unitOfWork.Rooms.GetRoomWithBuildingAndType(room.Id);

            var result = mapper.Map<Room, RoomResource>(room);

            return Ok(result);
        }

        [HttpGet("{typeId}")]
        public async  Task<IActionResult> GetRoomsBasedOnType([FromRoute] int typeId)
        {
            var rooms = await unitOfWork.Rooms.GetRooms(typeId);

            var result = mapper.Map<IEnumerable<Room>, IEnumerable<RoomResource>>(rooms);
            
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await unitOfWork.Rooms.GetRooms();

            var result = mapper.Map<IEnumerable<Room>, IEnumerable<RoomResource>>(rooms);
            
            return Ok(result);
        }
    }
}