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
        var result = _context.Students.FirstOrDefault(x => x.Id == course.Id);

        if (result is null)
            throw new Exception("Course not found.");

        _context.Students.Update(result);

        await _context.SaveChangesAsync();
    }

    public async Task<Course> GetCourseById(int id)
    {
        var course = _context.Courses.FirstOrDefault(x => x.Id == id);
        if (course is null)
           return new Course();
        
        return course;
    }

    public async Task<IEnumerable<Course>> GetCourses()
    {
        return _context.Courses;
    }
    
    public async Task DeleteCourse(int id)
    {
        var course = _context.Courses.FirstOrDefault(x => x.Id == id);

        if (course is null)
            throw new Exception("Course not found.");

        if (course != null)
            _context.Courses.Remove(course);

        await _context.SaveChangesAsync();
    }
}
