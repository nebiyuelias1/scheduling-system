﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchedulingSystem.Persistence;

namespace SchedulingSystem.Migrations
{
    [DbContext(typeof(SchedulingDbContext))]
    [Migration("20181219061046_RenameCourseTableToCourses")]
    partial class RenameCourseTableToCourses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("SchedulingSystem.Models.Course", b =>
                {
                    b.HasOne("SchedulingSystem.Models.Curriculum", "Curriculum")
                        .WithMany()
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade);
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
#pragma warning restore 612, 618
        }
    }
}
