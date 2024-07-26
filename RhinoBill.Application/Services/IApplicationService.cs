using StudentApplication = RhinoBill.Core;
namespace RhinoBill.Application;

public interface IApplicationService
{
    Task AddApplication(StudentApplication.Application student);   
    Task UpdateApplication(StudentApplication.Application student);   
    Task DeleteStudent(int id);   
    Task<IEnumerable<StudentApplication.Application>> GetApplications();   
    Task<StudentApplication.Application> GetSApplicationsByStudentId(int id);  
}
