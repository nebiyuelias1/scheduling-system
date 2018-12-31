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
        public DbSet<Course> Course { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<RoomType> RoomAssignmentTypes { get; set; }
        public SchedulingDbContext(DbContextOptions<SchedulingDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<RoomSectionAssignment>()
                .HasKey(rs => new { rs.SectionId, rs.RoomId, rs.TypeId });
        }
    }
}