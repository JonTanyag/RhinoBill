
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
    
    public async Task AddApplication(Core.Application application)
    {
         _context.Applications.Add(application);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateApplication(Core.Application application)
    {
        var result = _context.Applications.FirstOrDefault(x => x.Id == application.Id);

        if (result is null)
            throw new Exception("Application not found.");

        _context.Applications.Update(result);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Core.Application>> GetApplications()
    {
        return _context.Applications;
    }

    public async Task<Core.Application> GetApplicationsById(int id)
    {
         var application = _context.Applications
                                    .Include(x => x.Students)
                                    .Include(x => x.Courses)
                                    .FirstOrDefault(x => x.Id == id);

        if (application is null)
           return new Core.Application();
        
        return application;
    }

    public async Task DeleteApplication(int id)
    {
        var application = _context.Applications.FirstOrDefault(x => x.Id == id);

        if (application is null)
            throw new Exception("Application not found.");

        _context.Applications.Remove(application);

        await _context.SaveChangesAsync();
    }
}
