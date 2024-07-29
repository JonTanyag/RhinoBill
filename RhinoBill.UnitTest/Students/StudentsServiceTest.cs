using Microsoft.EntityFrameworkCore;
using Moq;
using RhinoBill.Application;
using RhinoBill.Core;
using RhinoBill.Infrastructure;
using Shouldly;

namespace RhinoBill.UnitTest;

[TestFixture]
public class StudentsServiceTest
{
    private RhinoBillDbContext _context;
    private IStudentService _studentService;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<RhinoBillDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

        _context = new RhinoBillDbContext(options);
        _studentService = new StudentService(_context);

        // Seed the database with a student
        _context.Students.Add(new Student { Id = 1, FirstName = "John", LastName = "Smith", Email = "test@email.com", PhoneNumber = "9237489" });
        _context.SaveChanges();
    }

    [Test]
    public async Task CreateStudent_ShouldAddNewStudent()
    {
        // Arrange
        var newStudent = new Student { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "test@email.com", PhoneNumber = "982347" };

        // Act
        await _studentService.AddStudent(newStudent, CancellationToken.None);

        // Assert
        var createdStudent = await _context.Students.FindAsync(newStudent.Id);
        createdStudent.ShouldNotBeNull();
        createdStudent.FirstName.ShouldBe("Jane");
        createdStudent.LastName.ShouldBe("Doe");
    }

    [Test]
    public async Task GetStudents_ShouldReturnAllStudents()
    {
        // Act
        var result = await _studentService.GetStudents(CancellationToken.None);

        // Assert
        result.Count().ShouldBe(1);
        result.First().FirstName.ShouldBe("John");
        result.First().LastName.ShouldBe("Smith");
    }

    [Test]
    public async Task GetStudentById_ShouldReturnStudentWithGivenId()
    {
        // Act
        var result = await _studentService.GetStudentById(1, CancellationToken.None);

        // Assert
        result.ShouldNotBeNull();
        result.FirstName.ShouldBe("John");
        result.LastName.ShouldBe("Smith");
    }

    [Test]
    public async Task DeleteStudent_ShouldRemoveStudentWithGivenId()
    {
        // Act
        await _studentService.DeleteStudent(1, CancellationToken.None);

        // Assert
        var deletedStudent = await _context.Students.FindAsync(1);
        deletedStudent.ShouldBeNull();
    }

    [Test]
    public async Task UpdateStudentAsync_ShouldUpdateExistingStudent()
    {
        // Arrange
        var studentToUpdate = new Student { Id = 1, FirstName = "Jane", LastName = "Doe", Email = "testupdate@email.com", PhoneNumber = "9237489" };

        // Act
        await _studentService.UpdateStudent(studentToUpdate, CancellationToken.None);

        // Assert
        var updatedStudent = await _context.Students.FindAsync(studentToUpdate.Id);
        updatedStudent.ShouldNotBeNull();
        updatedStudent.FirstName.ShouldBe("Jane");
        updatedStudent.LastName.ShouldBe("Doe");
    }
}

