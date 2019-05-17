﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Migrations
{
    [DbContext(typeof(SchedulingDbContext))]
    [Migration("20190517054626_AddIsActiveColumnToSection")]
    partial class AddIsActiveColumnToSection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.AcademicSemester", b =>
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

            modelBuilder.Entity("SchedulingSystem.Core.Models.AcademicYear", b =>
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

            modelBuilder.Entity("SchedulingSystem.Core.Models.AdmissionLevel", b =>
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

            modelBuilder.Entity("SchedulingSystem.Core.Models.Building", b =>
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

            modelBuilder.Entity("SchedulingSystem.Core.Models.College", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Course", b =>
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

                    b.Property<int>("Lab");

                    b.Property<int>("Lecture");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Tutor");

                    b.HasKey("Id");

                    b.HasIndex("CurriculumId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.CourseOffering", b =>
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

            modelBuilder.Entity("SchedulingSystem.Core.Models.Curriculum", b =>
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

            modelBuilder.Entity("SchedulingSystem.Core.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ScheduleId");

                    b.Property<int?>("WeekDayId");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("WeekDayId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Department", b =>
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

            modelBuilder.Entity("SchedulingSystem.Core.Models.Duration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime");

                    b.Property<int?>("ScheduleConfigurationAdmissionLevelId");

                    b.Property<int?>("ScheduleConfigurationProgramTypeId");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleConfigurationAdmissionLevelId", "ScheduleConfigurationProgramTypeId");

                    b.ToTable("Duration");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Instructor", b =>
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

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.InstructorAssignment", b =>
                {
                    b.Property<int>("CourseOfferingId");

                    b.Property<int>("InstructorId");

                    b.Property<int>("TypeId");

                    b.HasKey("CourseOfferingId", "InstructorId", "TypeId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("TypeId");

                    b.ToTable("InstructorAssignments");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.ProgramType", b =>
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

            modelBuilder.Entity("SchedulingSystem.Core.Models.Room", b =>
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

            modelBuilder.Entity("SchedulingSystem.Core.Models.RoomTypeAssignment", b =>
                {
                    b.Property<int>("RoomId");

                    b.Property<int>("TypeId");

                    b.HasKey("RoomId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("RoomTypeAssignments");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicSemesterId");

                    b.Property<int>("SectionId");

                    b.HasKey("Id");

                    b.HasIndex("AcademicSemesterId");

                    b.HasIndex("SectionId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.ScheduleConfiguration", b =>
                {
                    b.Property<int>("AdmissionLevelId");

                    b.Property<int>("ProgramTypeId");

                    b.Property<int>("NumberOfDaysPerWeek");

                    b.Property<int>("NumberOfPeriodsPerDay");

                    b.HasKey("AdmissionLevelId", "ProgramTypeId");

                    b.HasIndex("ProgramTypeId");

                    b.ToTable("ScheduleConfigurations");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.ScheduleEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int>("DayId");

                    b.Property<int>("Duration");

                    b.Property<int>("InstructorId");

                    b.Property<int>("Period");

                    b.Property<int>("RoomId");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DayId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TypeId");

                    b.ToTable("ScheduleEntries");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdmissionLevelId");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("EntranceYear");

                    b.Property<bool>("IsActive");

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

            modelBuilder.Entity("SchedulingSystem.Core.Models.SectionRoomAssignment", b =>
                {
                    b.Property<int>("SectionId");

                    b.Property<int>("RoomId");

                    b.Property<int>("TypeId");

                    b.HasKey("SectionId", "RoomId", "TypeId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TypeId");

                    b.ToTable("SectionRoomAssignments");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.WeekDay", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.AcademicSemester", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.AcademicYear", "AcademicYear")
                        .WithMany("AcademicSemesters")
                        .HasForeignKey("AcademicYearId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Course", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.Curriculum", "Curriculum")
                        .WithMany()
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.CourseOffering", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.AcademicSemester", "AcademicSemester")
                        .WithMany()
                        .HasForeignKey("AcademicSemesterId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SchedulingSystem.Core.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SchedulingSystem.Core.Models.Section", "Section")
                        .WithMany("CourseOfferings")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Curriculum", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Day", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.Schedule", "Schedule")
                        .WithMany("Days")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SchedulingSystem.Core.Models.WeekDay", "WeekDay")
                        .WithMany()
                        .HasForeignKey("WeekDayId");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Department", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.College", "College")
                        .WithMany("Departments")
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Duration", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.ScheduleConfiguration")
                        .WithMany("Durations")
                        .HasForeignKey("ScheduleConfigurationAdmissionLevelId", "ScheduleConfigurationProgramTypeId");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Instructor", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.InstructorAssignment", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.CourseOffering", "CourseOffering")
                        .WithMany("Instructors")
                        .HasForeignKey("CourseOfferingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Room", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.RoomTypeAssignment", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.Room", "Room")
                        .WithMany("Types")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Schedule", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.AcademicSemester", "AcademicSemester")
                        .WithMany()
                        .HasForeignKey("AcademicSemesterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.ScheduleConfiguration", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.AdmissionLevel", "AdmissionLevel")
                        .WithMany()
                        .HasForeignKey("AdmissionLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.ProgramType", "ProgramType")
                        .WithMany()
                        .HasForeignKey("ProgramTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.ScheduleEntry", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Day", "Day")
                        .WithMany("Periods")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SchedulingSystem.Core.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.Section", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.AdmissionLevel", "AdmissionLevel")
                        .WithMany()
                        .HasForeignKey("AdmissionLevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.ProgramType", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchedulingSystem.Core.Models.SectionRoomAssignment", b =>
                {
                    b.HasOne("SchedulingSystem.Core.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Section", "Section")
                        .WithMany("RoomAssignments")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchedulingSystem.Core.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
