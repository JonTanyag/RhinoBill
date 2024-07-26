using RhinoBill.Core;

namespace RhinoBill.Application;

public interface IStudentService
{
    Task AddStudent(Student student);   
    Task UpdateStudent(Student student);   
    Task DeleteStudent(int id);   
    Task<IEnumerable<Student>> GetStudents();   
    Task<Student> GetStudentById(int id);   
}
