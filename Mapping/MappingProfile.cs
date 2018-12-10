using AutoMapper;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Models;

namespace SchedulingSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // API Resource to Domain
            CreateMap<DepartmentResource, Department>();

            // Domain to API Resource
            CreateMap<Department, DepartmentResource>();
        }
    }
}