using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Models;

namespace SchedulingSystem.Persistence
{
    public class SchedulingDbContext : DbContext
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
        public DbSet<Type> RoomTypes { get; set; }
        public DbSet<AcademicSemester> AcademicSemesters { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<CourseOffering> CourseOfferings { get; set; }
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

            modelbuilder.Entity<CourseOffering>()
                .HasOne(co => co.Instructor)
                .WithMany()
                .HasForeignKey(co => co.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<CourseOffering>()
                .HasOne(co => co.Section)
                .WithMany(s => s.CourseOfferings)
                .HasForeignKey(co => co.SectionId)
                .OnDelete(DeleteBehavior.Restrict);
                        
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
                
            base.OnModelCreating(modelbuilder);
        }
    }
}