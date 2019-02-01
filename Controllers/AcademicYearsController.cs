using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core.Models;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Controllers
{
    [Route("/api/[controller]")]
    public class AcademicYearsController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IMapper mapper;

        public AcademicYearsController(SchedulingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveAcademicYearResource resource) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var academicYear = mapper.Map<SaveAcademicYearResource, AcademicYear>(resource);
            
            context.AcademicYears.Add(academicYear);
            await context.SaveChangesAsync();

            academicYear = await context.AcademicYears
                            .Include(ay => ay.AcademicSemesters)
                            .SingleOrDefaultAsync(ay => ay.Id == academicYear.Id);

            var result = mapper.Map<AcademicYear, AcademicYearResource>(academicYear);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAcademicYears()
        {
           var academicYears = await context.AcademicYears.ToListAsync();

           if (academicYears == null)
           {
               return NotFound();
           }

           var academicYearsResource = mapper.Map<IList<AcademicYear>, IList<AcademicYearResource>>(academicYears);

           return Ok(academicYearsResource);
        }
    }
}