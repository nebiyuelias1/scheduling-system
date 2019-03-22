using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Controllers
{
    [Route("/api/[controller]")]
    public class WeekDaysController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public WeekDaysController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeekDays()
        {
            var weekDays = await unitOfWork.WeekDays
                            .GetAll();

            var weekDaysResource = mapper.Map<IEnumerable<WeekDay>, IEnumerable<WeekDayResource>>(weekDays)
                                        .OrderBy(w => w.Number);
            
            return Ok(weekDaysResource);
        }
    }
}