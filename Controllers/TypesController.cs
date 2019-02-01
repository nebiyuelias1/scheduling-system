using System.Collections.Generic;
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
    public class TypesController : Controller
    {
        private readonly SchedulingDbContext context;
        private readonly IMapper mapper;

        public TypesController(SchedulingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypes()
        {
            var types = await context.Types.ToListAsync();

            if (types == null)
                return NotFound();

            var typesResource = mapper.Map<IList<Type>, IList<KeyValuePairResource>>(types);

            return Ok(typesResource);
        }
    }
}