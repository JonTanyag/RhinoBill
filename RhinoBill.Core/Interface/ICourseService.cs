using RhinoBill.Core;

namespace RhinoBill.Application;

public interface ICourseService
{
    Task AddCourse(Course course);   
    Task UpdateCourse(Course course);   
    Task DeleteCourse(int id);   
    Task<IEnumerable<Course>> GetCourses();   
    Task<Course> GetCourseById(int id);  
}
