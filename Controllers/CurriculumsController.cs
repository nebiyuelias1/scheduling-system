using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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