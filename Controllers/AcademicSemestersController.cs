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
    public class AcademicSemestersController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IMapper mapper;

        public AcademicSemestersController(SchedulingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveAcademicSemesterResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var academicSemester = mapper.Map<SaveAcademicSemesterResource, AcademicSemester>(resource);

            context.AcademicSemesters.Add(academicSemester);
            await context.SaveChangesAsync();

            academicSemester = await context.AcademicSemesters
                                .Include(s => s.AcademicYear)
                                .SingleOrDefaultAsync(s => s.Id == academicSemester.Id);

            var result = mapper.Map<AcademicSemester, AcademicSemesterResource>(academicSemester);

            return Ok(result);
        }
    }
}