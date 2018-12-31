using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/[controller]")]
    public class RoomAssignmentTypesController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IMapper mapper;

        public RoomAssignmentTypesController(SchedulingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypes()
        {
            var types = await context.RoomTypes.ToListAsync();

            if (types == null)
                return NotFound();

            var typesResource = mapper.Map<IList<RoomType>, IList<KeyValuePairResource>>(types);

            return Ok(typesResource);
        }
    }
}