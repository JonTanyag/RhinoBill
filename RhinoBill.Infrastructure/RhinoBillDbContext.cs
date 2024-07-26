using Microsoft.EntityFrameworkCore;
using RhinoBill.Core;

namespace RhinoBill.Infrastructure;

public class RhinoBillDbContext : DbContext
{
    public RhinoBillDbContext()
    {
        
    }
    public RhinoBillDbContext(DbContextOptions<RhinoBillDbContext> options)
    : base(options)
    {
        
    }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and seed data
        modelBuilder.Entity<Application>()
            .HasKey(a => new { a.StudentId, a.CourseId });

        modelBuilder.Entity<Application>()
            .HasOne(a => a.Students)
            .WithMany(s => s.Applications)
            .HasForeignKey(a => a.StudentId);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.Courses)
            .WithMany(c => c.Applications)
            .HasForeignKey(a => a.CourseId);
    }
}
