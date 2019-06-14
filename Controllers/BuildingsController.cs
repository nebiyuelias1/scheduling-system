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
    [Route("/api/buildings")]
    public class BuildingsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public BuildingsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BuildingResource buildingResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var building = mapper.Map<BuildingResource, Building>(buildingResource);

            unitOfWork.Buildings.Add(building);
            await unitOfWork.CompleteAsync();
            
            buildingResource = mapper.Map<Building, BuildingResource>(building);

            return Ok(buildingResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetBuildings()
        {
            var buildings = await unitOfWork.Buildings.GetAll();

            if (buildings == null)
                return NotFound();

            var buildingResources = mapper.Map<IEnumerable<Building>, IEnumerable<BuildingResource>>(buildings);

            return Ok(buildingResources);
        }
    }
}