﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Migrations
{
    [DbContext(typeof(SchedulingDbContext))]
    partial class SchedulingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchedulingSystem.Models.AcademicSemester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicYearId");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsCurrentSemester");

                    b.Property<byte>("Semester");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("AcademicYearId");

                    b.ToTable("AcademicSemesters");
                });

            modelBuilder.Entity("SchedulingSystem.Models.AcademicYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("EtYear")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("GcYear")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("AcademicYears");
                });

            modelBuilder.Entity("SchedulingSystem.Models.AdmissionLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("AdmissionLevels");
                });

            modelBuilder.Entity("SchedulingSystem.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("SchedulingSystem.Models.College", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("SchedulingSystem.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("CurriculumId");

                    b.Property<byte>("DeliverySemester");

                    b.Property<byte>("DeliveryYear");

                    b.Property<byte>("Lab");

                    b.Property<byte>("Lecture");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<byte>("Tutor");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SchedulingSystem.Models.CourseOffering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AcademicSemesterId");

                    b.Property<int?>("CourseId");

                    b.Property<int?>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("AcademicSemesterId");

                    b.HasIndex("CourseId");

                    b.HasIndex("SectionId");

                    b.ToTable("CourseOfferings");
                });

            modelBuilder.Entity("SchedulingSystem.Models.Curriculum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Nomenclature")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<byte>("StaySemester");

                    b.Property<byte>("StayYear");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Curriculums");
                });

            modelBuilder.Entity("SchedulingSystem.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CollegeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CollegeId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SchedulingSystem.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("GrandFatherName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("SchedulingSystem.Models.InstructorAssignment", b =>
                {
                    b.Property<int>("CourseOfferingId");

                    b.Property<int>("InstructorId");

                    b.Property<int>("TypeId");

                    b.HasKey("CourseOfferingId", "InstructorId", "TypeId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("TypeId");

                    b.ToTable("InstructorAssignments");
                });

            modelBuilder.Entity("SchedulingSystem.Models.ProgramType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ProgramTypes");
                });

            modelBuilder.Entity("SchedulingSystem.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("SchedulingSystem.Models.RoomTypeAssignment", b =>
                {
                    b.Property<int>("RoomId");

                    b.Property<int>("TypeId");

                    b.HasKey("RoomId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("RoomTypeAssignments");
                });

            modelBuilder.Entity("SchedulingSystem.Models.ScheduleConfiguration", b =>
                {
                    b.Property<int>("AdmissionLevelId");

                    b.Property<int>("ProgramTypeId");

                    b.Property<int>("NumberOfDaysPerWeek");

                    b.Property<int>("NumberOfPeriodsPerDay");

                    b.HasKey("AdmissionLevelId", "ProgramTypeId");

                    b.HasIndex("ProgramTypeId");

                    b.ToTable("ScheduleConfigurations");
                });

            modelBuilder.Entity("SchedulingSystem.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdmissionLevelId");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("EntranceYear");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("ProgramTypeId");

                    b.Property<int>("StudentCount");

                    b.HasKey("Id");

                    b.HasIndex("AdmissionLevelId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ProgramTypeId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("SchedulingSystem.Models.SectionRoomAssignment", b =>
                {
                    b.Property<int>("SectionId");

                    b.Property<int>("RoomId");

                    b.Property<int>("TypeId");

                    b.HasKey("SectionId", "RoomId", "TypeId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TypeId");

                    b.ToTable("SectionRoomAssignments");
                });

            modelBuilder.Entity("SchedulingSystem.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("SchedulingSystem.Models.WeekDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.ToTable("WeekDays");
                });

            modelBuilder.Entity("SchedulingSystem.Models.AcademicSemester", b =>
                {
                    b.HasOne("SchedulingSystem.Models.AcademicYear", "AcademicYear")
                        .WithMany("AcademicSemesters")
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.Course", b =>
                {
                    b.HasOne("SchedulingSystem.Models.Curriculum", "Curriculum")
                        .WithMany()
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.CourseOffering", b =>
                {
                    b.HasOne("SchedulingSystem.Models.AcademicSemester", "AcademicSemester")
                        .WithMany()
                        .HasForeignKey("AcademicSemesterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SchedulingSystem.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SchedulingSystem.Models.Section", "Section")
                        .WithMany("CourseOfferings")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SchedulingSystem.Models.Curriculum", b =>
                {
                    b.HasOne("SchedulingSystem.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.Department", b =>
                {
                    b.HasOne("SchedulingSystem.Models.College", "College")
                        .WithMany("Departments")
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.Instructor", b =>
                {
                    b.HasOne("SchedulingSystem.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.InstructorAssignment", b =>
                {
                    b.HasOne("SchedulingSystem.Models.CourseOffering", "CourseOffering")
                        .WithMany("Instructors")
                        .HasForeignKey("CourseOfferingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.Room", b =>
                {
                    b.HasOne("SchedulingSystem.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.RoomTypeAssignment", b =>
                {
                    b.HasOne("SchedulingSystem.Models.Room", "Room")
                        .WithMany("Types")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.ScheduleConfiguration", b =>
                {
                    b.HasOne("SchedulingSystem.Models.AdmissionLevel", "AdmissionLevel")
                        .WithMany()
                        .HasForeignKey("AdmissionLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Models.ProgramType", "ProgramType")
                        .WithMany()
                        .HasForeignKey("ProgramTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.Section", b =>
                {
                    b.HasOne("SchedulingSystem.Models.AdmissionLevel", "AdmissionLevel")
                        .WithMany()
                        .HasForeignKey("AdmissionLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Models.ProgramType", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Models.SectionRoomAssignment", b =>
                {
                    b.HasOne("SchedulingSystem.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Models.Section", "Section")
                        .WithMany("RoomAssignments")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
