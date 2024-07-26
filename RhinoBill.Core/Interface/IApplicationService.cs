
namespace RhinoBill.Core;

public interface IApplicationService
{
    Task AddApplication(Application application, CancellationToken cancellationToken);   
    Task UpdateApplication(Application application, CancellationToken cancellationToken);   
    Task DeleteApplication(int id, CancellationToken cancellationToken);   
    Task<IEnumerable<Application>> GetApplications(CancellationToken cancellationToken);   
    Task<Application> GetApplicationsById(int id, CancellationToken cancellationToken);  
}
