using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoMapper;
using SchedulingSystem.Controllers.Resources;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // API Resource to Domain
            CreateMap<DepartmentResource, Department>();
            CreateMap<CurriculumResource, Curriculum>();
            CreateMap<SaveCourseResource, Course>();
            CreateMap<BuildingResource, Building>();
            CreateMap<SaveRoomResource, Room>();
            CreateMap<SaveSectionResource, Section>();
            CreateMap<SaveSectionResource, Section>();
            CreateMap<InstructorResource, Instructor>();
            CreateMap<SaveRoomResource, Room>()
                .ForMember(r => r.Types, opt => opt.MapFrom(sr => sr.Types.Select(t => new RoomTypeAssignment { TypeId = t.TypeId, LabTypeId = t.LabTypeId })));
            CreateMap<SaveRoomSectionAssignmentResource, CourseOfferingRoomAssignment>();
            CreateMap<SaveAcademicYearResource, AcademicYear>();
            CreateMap<SaveAcademicSemesterResource, AcademicSemester>();
            CreateMap<SaveAssignmentResource, InstructorAssignment>();
            CreateMap<SaveScheduleConfigurationResource, ScheduleConfiguration>();
            CreateMap<SaveInstructorResource, Instructor>();
            CreateMap<InstructorQueryResource, InstructorQuery>();
            CreateMap<SaveBuildingResource, Building>();
            CreateMap<SaveDepartmentResource, Department>();
            CreateMap<CurriculumQueryResource, CurriculumQuery>();
            CreateMap<CourseQueryResource, CourseQuery>();
            CreateMap<SectionQueryResource, SectionQuery>();
            CreateMap<RoomQueryResource, RoomQuery>();

            // Domain to API Resource
            CreateMap<Department, DepartmentResource>();
            CreateMap<Curriculum, CurriculumResource>();
            CreateMap<Course, SaveCourseResource>();
            CreateMap<Building, BuildingResource>();
            CreateMap<Room, SaveRoomResource>()
                .ForMember(x => x.Types, opt => opt.MapFrom(r => r.Types.Select(t => new RoomTypeAssignmentResource { TypeId = t.TypeId, LabTypeId = t.LabTypeId })));
            CreateMap<Section, SaveSectionResource>();
            CreateMap<Section, SectionResource>()
                .ForMember(x => x.Program, opt =>
                    opt.MapFrom(s =>  s.Program.Name ))
                .ForMember(x => x.AdmissionLevel, opt =>
                    opt.MapFrom(s => s.AdmissionLevel.Name ));
            CreateMap<Instructor, InstructorResource>();
            CreateMap<Type, KeyValuePairResource>();
            CreateMap<Room, RoomResource>();
            CreateMap<RoomTypeAssignment, KeyValuePairResource>()
                .ForMember(kvp => kvp.Id, opt => opt.MapFrom(rrt => rrt.Type.Id))
                .ForMember(kvp => kvp.Name, opt => opt.MapFrom(rrt => rrt.Type.Name));
            CreateMap<CourseOfferingRoomAssignment, CourseOfferingRoomAssignmentResource>();
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
            CreateMap<InstructorAssignment, InstructorAssignmentResource>();
            CreateMap<ScheduleConfiguration, ScheduleConfigurationResource>();
            CreateMap<AdmissionLevel, KeyValuePairResource>();
            CreateMap<ProgramType, KeyValuePairResource>();
            CreateMap<Course, CourseResource>();
            CreateMap<Schedule, ScheduleResource>()
                .ForMember(sr => sr.TimeTable, opt => opt.Ignore());
            CreateMap<WeekDay, WeekDayResource>();
            CreateMap<AppUser, AppUserResource>()
                .ForMember(aur => aur.FirstName, opt => opt.MapFrom(au => au.Contact.FirstName))
                .ForMember(aur => aur.FatherName, opt => opt.MapFrom(au => au.Contact.FatherName))
                .ForMember(aur => aur.GrandFatherName, opt => opt.MapFrom(au => au.Contact.GrandFatherName))
                .ForMember(aur => aur.DepartmentId, opt => opt.MapFrom(au => au.Contact.DepartmentId))
                .ForMember(aur => aur.Department, opt => opt.MapFrom(au => au.Contact.Department));
            CreateMap<QueryResult<Instructor>, QueryResultResource<InstructorResource>>();
            CreateMap<QueryResult<Curriculum>, QueryResultResource<CurriculumResource>>();
            CreateMap<QueryResult<Course>, QueryResultResource<CourseResource>>();
            CreateMap<QueryResult<Section>, QueryResultResource<SectionResource>>();
            CreateMap<QueryResult<Room>, QueryResultResource<RoomResource>>();
            CreateMap<College, CollegeResource>();
            CreateMap<Building, SaveBuildingResource>();
            CreateMap<AppUser, DeptHeadResource>()
                .ForMember(aur => aur.FirstName, opt => opt.MapFrom(au => au.Contact.FirstName))
                .ForMember(aur => aur.FatherName, opt => opt.MapFrom(au => au.Contact.FatherName))
                .ForMember(aur => aur.GrandFatherName, opt => opt.MapFrom(au => au.Contact.GrandFatherName));
            CreateMap<LabType, KeyValuePairResource>();
        }
    }
}