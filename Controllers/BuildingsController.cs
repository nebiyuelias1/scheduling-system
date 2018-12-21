using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/buildings")]
    public class BuildingsController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IMapper mapper;

        public BuildingsController(SchedulingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BuildingResource buildingResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var building = mapper.Map<BuildingResource, Building>(buildingResource);
            
            context.Buildings.Add(building);
            await context.SaveChangesAsync();

            buildingResource = mapper.Map<Building, BuildingResource>(building);

            return Ok(buildingResource);
        }
    }
}