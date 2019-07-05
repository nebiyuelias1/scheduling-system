using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core;
using SchedulingSystem.Core.Models;

[Route("/api/[controller]")]
public class LabTypesController : Controller
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public LabTypesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var labTypes = await unitOfWork.LabTypes.GetAll();

        if (labTypes == null)
            return NotFound();

        var result = mapper.Map<IEnumerable<LabType>, IEnumerable<KeyValuePairResource>>(labTypes);

        return Ok(result);
    }
}