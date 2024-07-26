using RhinoBill.Core;
using RhinoBill.Infrastructure;

namespace RhinoBill.Application;

public class CourseService : ICourseService
{
    private readonly RhinoBillDbContext _context;
    public CourseService(RhinoBillDbContext context)
    {
        _context = context;
    }

    public async Task AddCourse(Course course)
    {
        _context.Courses.Add(course);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateCourse(Course course)
    {
        throw new NotImplementedException();
    }

    public async Task<Course> GetCourseById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Course>> GetCourses()
    {
        return _context.Courses;
    }
    
    public async Task DeleteCourse(int id)
    {
        throw new NotImplementedException();
    }
}
