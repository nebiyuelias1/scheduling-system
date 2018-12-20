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
    [Route("/api/curriculums")]
    public class CurriculumsController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IMapper mapper;

        public CurriculumsController(SchedulingDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurriculums()
        {
            var curriculums = await context.Curriculums.ToListAsync();

            if (curriculums == null)
                return NotFound();

            var curriculumResource = mapper.Map<IList<Curriculum>, IList<CurriculumResource>>(curriculums);

            return Ok(curriculumResource);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CurriculumResource curriculumResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var curriculum = mapper.Map<CurriculumResource, Curriculum>(curriculumResource);

            context.Curriculums.Add(curriculum);
            context.SaveChanges();

            mapper.Map<Curriculum, CurriculumResource>(curriculum, curriculumResource);

            return Ok(curriculumResource);
        }
    }
}