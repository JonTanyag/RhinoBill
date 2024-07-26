using RhinoBill.Core;

namespace RhinoBill.Application;

public interface ICourseService
{
    Task AddCourse(Course course, CancellationToken cancellationToken);   
    Task UpdateCourse(Course course, CancellationToken cancellationToken);   
    Task DeleteCourse(int id, CancellationToken cancellationToken);   
    Task<IEnumerable<Course>> GetCourses(CancellationToken cancellationToken);   
    Task<Course> GetCourseById(int id, CancellationToken cancellationToken);  
}
