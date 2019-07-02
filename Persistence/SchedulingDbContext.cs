using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Core.Models;

namespace SchedulingSystem.Persistence
{
    public class SchedulingDbContext : IdentityDbContext<AppUser>
    {

        public DbSet<College> Colleges { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgramType> ProgramTypes { get; set; }
        public DbSet<AdmissionLevel> AdmissionLevels { get; set; }
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<AcademicSemester> AcademicSemesters { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<CourseOffering> CourseOfferings { get; set; }
        public DbSet<InstructorAssignment> CourseOfferingInstructorAssignments { get; set; }
        public DbSet<ScheduleConfiguration> ScheduleConfigurations { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }
        public DbSet<ScheduleEntry> ScheduleEntries { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<LabType> LabTypes { get; set; }
        public SchedulingDbContext(DbContextOptions<SchedulingDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<SectionRoomAssignment>()
                .HasKey(rs => new { rs.SectionId, rs.RoomId, rs.TypeId });

            modelbuilder.Entity<RoomTypeAssignment>()
                .HasKey(rt => new { rt.RoomId, rt.TypeId });


            modelbuilder.Entity<ScheduleConfiguration>()
                .HasKey(s => new { s.AdmissionLevelId, s.ProgramTypeId });

            modelbuilder.Entity<CourseOffering>()
                .HasOne(co => co.Section)
                .WithMany(s => s.CourseOfferings)
                .HasForeignKey(co => co.SectionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<CourseOffering>()
                .HasMany(co => co.Instructors)
                .WithOne(i => i.CourseOffering)
                .OnDelete(DeleteBehavior.Cascade);
                        
            modelbuilder.Entity<CourseOffering>()
                .HasOne(co => co.Course)
                .WithMany()
                .HasForeignKey(co => co.CourseId)
                .OnDelete(DeleteBehavior.SetNull);
            
            modelbuilder.Entity<CourseOffering>()
                .HasOne(co => co.AcademicSemester)
                .WithMany()
                .HasForeignKey(co => co.AcademicSemesterId)
                .OnDelete(DeleteBehavior.SetNull);

            modelbuilder.Entity<ScheduleEntry>()
                .HasOne(s => s.Instructor)
                .WithMany()
                .HasForeignKey(s => s.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Schedule>()
                .HasMany(s => s.Days)
                .WithOne(d => d.Schedule)
                .HasForeignKey(s => s.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Instructor>()
                .HasOne(i => i.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelbuilder);
        }
    }
}