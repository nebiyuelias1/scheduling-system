using Microsoft.EntityFrameworkCore;
using SchedulingSystem.Models;

namespace SchedulingSystem.Persistence
{
    public class SchedulingDbContext : DbContext
    {
        public SchedulingDbContext(DbContextOptions<SchedulingDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<College> Colleges { get; set; }
    }
}