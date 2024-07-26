
namespace RhinoBill.Core;

public interface IApplicationService
{
    Task AddApplication(Application application);   
    Task UpdateApplication(Application application);   
    Task DeleteApplication(int id);   
    Task<IEnumerable<Application>> GetApplications();   
    Task<Application> GetApplicationsById(int id);  
}
