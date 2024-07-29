
using Microsoft.EntityFrameworkCore;
using RhinoBill.Core;
using RhinoBill.Infrastructure;

namespace RhinoBill.Application;

public class ApplicationService : IApplicationService
{
    private readonly RhinoBillDbContext _context;
    public ApplicationService(RhinoBillDbContext context)
    {
        _context = context;
    }
    
    public async Task AddApplication(Core.Application application, CancellationToken cancellationToken)
    {
        await _context.Applications.AddAsync(application, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateApplication(Core.Application application, CancellationToken cancellationToken)
    {
        var existingApplication = await _context.Applications.FindAsync(application.Id);
       
       if (existingApplication is null)
            throw new Exception("Course not found.");
            
        _context.Entry(existingApplication).State = EntityState.Detached;
        _context.Update(application);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Core.Application>> GetApplications(CancellationToken cancellationToken)
    {
        return  _context.Applications.Include(x => x.Students).Include(x => x.Courses);
    }

    public async Task<Core.Application> GetApplicationsById(int id, CancellationToken cancellationToken)
    {
        var application = await _context.Applications.Include(x => x.Courses).Include(x => x.Students)
        .FirstOrDefaultAsync(x => x.Id == id);// .FindAsync(id, cancellationToken);

        if (application is null)
           return new Core.Application();
        
        return application;
    }

    public async Task DeleteApplication(int id, CancellationToken cancellationToken)
    {
        var application = await _context.Applications.FindAsync(id);

        if (application is null)
            throw new Exception("Application not found.");

        _context.Applications.Remove(application);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
