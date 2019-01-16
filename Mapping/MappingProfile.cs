using System.Collections.ObjectModel;
using System.Linq;
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
            CreateMap<SaveRoomResource, Room>();
            CreateMap<SaveSectionResource, Section>();
            CreateMap<SaveSectionResource, Section>();
            CreateMap<InstructorResource, Instructor>();
            CreateMap<SaveRoomResource, Room>()
                .ForMember(r => r.Types, opt => opt.MapFrom(sr => sr.Types.Select(t => new RoomTypeAssignment { TypeId = t })));
            CreateMap<SaveRoomSectionAssignmentResource, SectionRoomAssignment>();
            CreateMap<SaveAcademicYearResource, AcademicYear>();
            CreateMap<SaveAcademicSemesterResource, AcademicSemester>();

            // Domain to API Resource
            CreateMap<Department, DepartmentResource>();
            CreateMap<Curriculum, CurriculumResource>();
            CreateMap<Course, CourseResource>();
            CreateMap<Building, BuildingResource>();
            CreateMap<Room, SaveRoomResource>();
            CreateMap<Section, SaveSectionResource> ();
            CreateMap<Section, SectionResource> ()
                .ForMember(x => x.Program, opt => 
                    opt.MapFrom(s => new KeyValuePairResource { Id = s.Program.Id, Name = s.Program.Name }))
                .ForMember(x => x.AdmissionLevel, opt => 
                    opt.MapFrom(s => new KeyValuePairResource { Id = s.AdmissionLevel.Id, Name = s.AdmissionLevel.Name }));
            CreateMap<Instructor, InstructorResource>();
            CreateMap<Type, KeyValuePairResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<RoomTypeAssignment, KeyValuePairResource>()
                .ForMember(kvp => kvp.Id, opt => opt.MapFrom(rrt => rrt.Type.Id))
                .ForMember(kvp => kvp.Name, opt => opt.MapFrom(rrt => rrt.Type.Name));
            CreateMap<Room, RoomResource>();
            CreateMap<SectionRoomAssignment, RoomSectionAssignmentResource>();
            CreateMap<AcademicYear, AcademicYearResource>();
            CreateMap<AcademicSemester, AcademicSemesterResource>()
                .ForMember(asr => asr.AcademicYear, opt => opt.MapFrom(s => 
                new SaveAcademicYearResource 
                { 
                    Id = s.AcademicYear.Id,
                    GcYear = s.AcademicYear.GcYear,
                    EtYear = s.AcademicYear.EtYear,
                    StartDate = s.AcademicYear.StartDate,
                    EndDate = s.AcademicYear.EndDate
                }));
            CreateMap<CourseOffering, CourseOfferingResource>();
        }
    }
}