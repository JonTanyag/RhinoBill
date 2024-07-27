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

    public async Task AddCourse(Course course, CancellationToken cancellationToken)
    {
        await _context.Courses.AddAsync(course, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateCourse(Course course, CancellationToken cancellationToken)
    {
        var existingCourse = await _context.Courses.FindAsync(course.Id);

        if (existingCourse is null)
            throw new Exception("Course not found.");

        
        _context.Entry(existingCourse).CurrentValues.SetValues(course);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Course> GetCourseById(int id, CancellationToken cancellationToken)
    {
        var course = _context.Courses.FirstOrDefault(x => x.Id == id);
        if (course is null)
           return new Course();
        
        return course;
    }

    public async Task<IEnumerable<Course>> GetCourses(CancellationToken cancellationToken)
    {
        return _context.Courses;
    }
    
    public async Task DeleteCourse(int id, CancellationToken cancellationToken)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course is null)
            throw new Exception("Course not found.");

        if (course != null)
            _context.Courses.Remove(course);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
