using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/[controller]")]
    public class SectionsController : Controller
    {
        private readonly IMapper mapper;
        private readonly SchedulingDbContext context;

        public SectionsController(IMapper mapper, SchedulingDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public IActionResult GetSections()
        {
            
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SectionResource sectionResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var section = mapper.Map<SectionResource, Section>(sectionResource);

            context.Sections.Add(section);
            await context.SaveChangesAsync();
            
            var result = mapper.Map<Section, SectionResource>(section);

            return Ok(result);
        }
    }
}