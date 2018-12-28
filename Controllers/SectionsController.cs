using System.Collections;
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
        public async Task<IActionResult> GetSections()
        {
            var sections = await context.Sections.ToListAsync();

            if (sections == null)
                return NotFound();

            var sectionsResource = mapper.Map<IList<Section>, IList<SaveSectionResource>>(sections);

            return Ok(sectionsResource);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveSectionResource sectionResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var section = mapper.Map<SaveSectionResource, Section>(sectionResource);

            context.Sections.Add(section);
            await context.SaveChangesAsync();
            
            var result = mapper.Map<Section, SaveSectionResource>(section);

            return Ok(result);
        }
    }
}