using Microsoft.EntityFrameworkCore;
using RhinoBill.Core;
using RhinoBill.Infrastructure;

namespace RhinoBill.Application;

public class StudentService : IStudentService
{
    private readonly RhinoBillDbContext _context;

    public StudentService(RhinoBillDbContext context)
    {
        _context = context;
    }

    public async Task AddStudent(Student student, CancellationToken cancellationToken)
    {
        await _context.Students.AddAsync(student, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateStudent(Student student, CancellationToken cancellationToken)
    {
        var existingStudent = await _context.Students.FindAsync(student.Id);

        if (existingStudent is null)
            throw new Exception("Student not founds.");
        
        _context.Entry(existingStudent).CurrentValues.SetValues(student);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Student> GetStudentById(int id, CancellationToken cancellationToken)
    {
        var student = _context.Students.Include(x => x.Applications).FirstOrDefault(x => x.Id == id);
        if (student is null)
            return new Student();

        return student;
    }

    public async Task<IEnumerable<Student>> GetStudents(CancellationToken cancellationToken)
    {
        return _context.Students.ToList();
    }

    public async Task DeleteStudent(int id, CancellationToken cancellationToken)
    {
        var student = await _context.Students.FindAsync(id);

        if (student is null)
            throw new Exception("Student not found.");

        if (student != null)
            _context.Students.Remove(student);

        await _context.SaveChangesAsync(cancellationToken);
    }

}
