
using RhinoBill.Core;

namespace RhinoBill.Application;

public class ApplicationService : IApplicationService
{
    public Task AddApplication(Core.Application application)
    {
        throw new NotImplementedException();
    }

    public Task DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Core.Application>> GetApplications()
    {
        throw new NotImplementedException();
    }

    public Task<Core.Application> GetSApplicationsByStudentId(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateApplication(Core.Application application)
    {
        throw new NotImplementedException();
    }
}
