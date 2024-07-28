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
    public virtual DbSet<Core.Application> Applications { get; set; }

}
