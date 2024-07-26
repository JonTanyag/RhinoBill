
namespace RhinoBill.Core;

public interface IApplicationService
{
    Task AddApplication(Application application);   
    Task UpdateApplication(Application application);   
    Task DeleteStudent(int id);   
    Task<IEnumerable<Application>> GetApplications();   
    Task<Application> GetSApplicationsByStudentId(int id);  
}
