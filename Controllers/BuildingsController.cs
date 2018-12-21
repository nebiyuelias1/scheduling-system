using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Controllers.Resources;

namespace SchedulingSystem.Controllers
{
    public class BuildingsController : Controller
    {
        public BuildingsController()
        {
            
        }

        [HttpPost]
        public IActionResult Create([FromBody] BuildingResource buildingResource)
        {

        }
    }
}