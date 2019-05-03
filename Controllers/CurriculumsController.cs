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
    [Route("/api/curriculums")]
    public class CurriculumsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CurriculumsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurriculum(int id)
        {
            var curriculum = await unitOfWork.Curriculums.Get(id);
            
            if (curriculum == null)
                return NotFound();

            var curriculumResource = mapper.Map<Curriculum, CurriculumResource>(curriculum);

            return Ok(curriculum);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurriculums()
        {
            var curriculums = await unitOfWork.Curriculums.GetAll();

            if (curriculums == null)
                return NotFound();

            var curriculumResource = mapper.Map<IEnumerable<Curriculum>, IEnumerable<CurriculumResource>>(curriculums);

            return Ok(curriculumResource);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CurriculumResource curriculumResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var curriculum = mapper.Map<CurriculumResource, Curriculum>(curriculumResource);

            unitOfWork.Curriculums.Add(curriculum);
            unitOfWork.CompleteAsync();

            mapper.Map<Curriculum, CurriculumResource>(curriculum, curriculumResource);

            return Ok(curriculumResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CurriculumResource curriculumResource) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var curriculum = await unitOfWork.Curriculums.Get(id);
            if (curriculum == null)
                return NotFound();

            curriculumResource.Id = curriculum.Id;
            mapper.Map<CurriculumResource, Curriculum>(curriculumResource, curriculum);
            await unitOfWork.CompleteAsync();

            curriculum = await unitOfWork.Curriculums.Get(curriculumResource.Id);
            mapper.Map<Curriculum, CurriculumResource>(curriculum, curriculumResource);

            return Ok(curriculumResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var curriculum = await unitOfWork.Curriculums.Get(id);
            
            if (curriculum == null)
                return NotFound();

            unitOfWork.Curriculums.Remove(curriculum);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}