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

    public async Task AddStudent(Student student)
    {
        _context.Students.Add(student);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateStudent(Student student)
    {
        var result = _context.Students.FirstOrDefault(x => x.Id == student.Id);

        if (student is null)
            throw new Exception("Student not found.");

        _context.Students.Update(student);

        await _context.SaveChangesAsync();
    }

    public async Task<Student> GetStudentById(int id)
    {
        var student = _context.Students.Include(x => x.Applications).FirstOrDefault(x => x.Id == id);
        if (student is null)
           return new Student();
        
        return student;
    }

    public async Task<IEnumerable<Student>> GetStudents()
    {
       return _context.Students.ToList();
    }

    public async Task DeleteStudent(int id)
    {
        var student = _context.Students.FirstOrDefault(x => x.Id == id);

        if (student is null)
            throw new Exception("Student not found.");

        if (student != null)
            _context.Students.Remove(student);

        await _context.SaveChangesAsync();
    }

}
