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
            CreateMap<RoomResource, Room>();
            CreateMap<SaveSectionResource, Section>();
            CreateMap<SectionResource, Section>();
            CreateMap<InstructorResource, Instructor>();

            // Domain to API Resource
            CreateMap<Department, DepartmentResource>();
            CreateMap<Curriculum, CurriculumResource>();
            CreateMap<Course, CourseResource>();
            CreateMap<Building, BuildingResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<Section, SaveSectionResource> ();
            CreateMap<Section, SectionResource> ()
                .ForMember(x => x.Program, opt => 
                    opt.MapFrom(s => new KeyValuePairResource { Id = s.Program.Id, Name = s.Program.Name }))
                .ForMember(x => x.AdmissionLevel, opt => 
                    opt.MapFrom(s => new KeyValuePairResource { Id = s.AdmissionLevel.Id, Name = s.AdmissionLevel.Name }));
            CreateMap<Instructor, InstructorResource>();
            CreateMap<RoomType, KeyValuePairResource>();
        }
    }
}