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
            CreateMap<CurriculumResource, Curriculum>();
            CreateMap<CourseResource, Course>();
            CreateMap<BuildingResource, Building>();

            // Domain to API Resource
            CreateMap<Department, DepartmentResource>();
            CreateMap<Curriculum, CurriculumResource>();
            CreateMap<Course, CourseResource>();
            CreateMap<Building, BuildingResource>();
        }
    }
}