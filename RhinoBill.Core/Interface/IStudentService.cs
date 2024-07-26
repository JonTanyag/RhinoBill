using RhinoBill.Core;

namespace RhinoBill.Application;

public interface IStudentService
{
    Task AddStudent(Student student, CancellationToken cancellationToken);   
    Task UpdateStudent(Student student, CancellationToken cancellationToken);   
    Task DeleteStudent(int id, CancellationToken cancellationToken);   
    Task<IEnumerable<Student>> GetStudents(CancellationToken cancellationToken);   
    Task<Student> GetStudentById(int id, CancellationToken cancellationToken);   
}
