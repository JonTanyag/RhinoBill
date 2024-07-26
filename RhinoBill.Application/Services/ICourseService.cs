using RhinoBill.Core;

namespace RhinoBill.Application;

public interface ICourseService
{
    Task AddCourse(Course student);   
    Task UpdateCourse(Course student);   
    Task DeleteCourse(int id);   
    Task<IEnumerable<Course>> GetCourses();   
    Task<Course> GetCourseById(int id);  
}
