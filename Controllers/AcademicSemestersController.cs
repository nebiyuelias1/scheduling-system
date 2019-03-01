using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Core.Repositories;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/[controller]")]
    public class AcademicSemestersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AcademicSemestersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveAcademicSemesterResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var academicSemester = mapper.Map<SaveAcademicSemesterResource, AcademicSemester>(resource);

            var currentActiveSemester = await unitOfWork.AcademicSemesters.GetCurrentAcademicSemester();
            if (currentActiveSemester != null)
                currentActiveSemester.IsCurrentSemester = false;
            
            academicSemester.IsCurrentSemester = true;
            unitOfWork.AcademicSemesters.Add(academicSemester);
            await unitOfWork.CompleteAsync();

            academicSemester = await unitOfWork.AcademicSemesters.GetAcademicSemester(academicSemester.Id);

            var result = mapper.Map<AcademicSemester, AcademicSemesterResource>(academicSemester);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentSemester()
        {
            var currentActiveSemester = await unitOfWork.AcademicSemesters.GetCurrentAcademicSemester();
            
            if (currentActiveSemester == null)
                return NotFound();
                
            return Ok(currentActiveSemester);
        }
    }
}