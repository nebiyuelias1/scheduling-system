using System.Collections;
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
    [Route("/api/[controller]")]
    public class SectionsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SectionsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSection(int id)
        {
            var section = await unitOfWork.Sections.GetSectionWithAssignedRooms(id);

            if (section == null)
                return NotFound();
                
            var sectionResource = mapper.Map<Section, SaveSectionResource>(section);

            return Ok(sectionResource);
        }

        [HttpGet]
        public async Task<QueryResultResource<SectionResource>> GetSections(SectionQueryResource queryResource)
        {
            var query = Mapper.Map<SectionQueryResource, SectionQuery>(queryResource);
            
            var result = await unitOfWork.Sections.GetSections(query);

            return mapper.Map<QueryResult<Section>, QueryResultResource<SectionResource>>(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveSectionResource sectionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var section = mapper.Map<SaveSectionResource, Section>(sectionResource);
            
            unitOfWork.Sections.Add(section);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Section, SaveSectionResource>(section);

            return Ok(result);
        }

        [HttpPost("{sectionId}/assign")]
        public async Task<IActionResult> AssignRoom(int sectionId, [FromBody] SaveRoomSectionAssignmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var section = await unitOfWork.Sections.Get(sectionId);

            if (section == null)
                return NotFound();

            var result = mapper.Map<SaveRoomSectionAssignmentResource, CourseOfferingRoomAssignment>(resource);
            //section.RoomAssignments.Add(result);
            await unitOfWork.CompleteAsync();

            section = await unitOfWork.Sections.GetSectionWithBuilding(section.Id);

            var sectionResource = mapper.Map<Section, SectionResource>(section);
            return Ok(sectionResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveSectionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var section = await unitOfWork.Sections.Get(id);
            if (section == null)
                return NotFound();

            resource.Id = section.Id;
            mapper.Map<SaveSectionResource, Section>(resource, section);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<Section, SectionResource>(section);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var section = await unitOfWork.Sections.Get(id);
            if (section == null || !section.IsActive)
                return NotFound();

            section.MakeInactive();
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}