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
    private Mock<RhinoBillDbContext> _mockContext;
    private Mock<DbSet<Student>> _mockDbSet;
    private IStudentService _mockStudentService;

    [SetUp]
    public void Setup()
    {
        _mockContext = new Mock<RhinoBillDbContext>(new DbContextOptions<RhinoBillDbContext>());
        _mockDbSet = new Mock<DbSet<Student>>();

        var students = new List<Student>
            {
                new Student { Id = 1, FirstName = "John", LastName = "Doe" },
                new Student { Id = 2, FirstName = "Jane", LastName = "Smith" }
            }.AsQueryable();

        _mockDbSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(students.Provider);
        _mockDbSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(students.Expression);
        _mockDbSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(students.ElementType);
        _mockDbSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(students.GetEnumerator());

        _mockContext.Setup(c => c.Students).Returns(_mockDbSet.Object);
        _mockStudentService = new StudentService(_mockContext.Object);
    }

    [Test]
    public async Task GetStudents_ShouldReturnAllStudents()
    {
        var result = await _mockStudentService.GetStudents(It.IsAny<CancellationToken>());

        result.ShouldNotBe(null);
        result.Count().ShouldBe(2);
        result.First().FirstName.ShouldBe("John");
    }

    [Test]
    public async Task GetStudentById_ShouldReturnStudent()
    {
        var student = new Student { Id = 1, FirstName = "John", LastName = "Doe" };
        _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(student);

        var result = await _mockStudentService.GetStudentById(1, It.IsAny<CancellationToken>());

        result.ShouldNotBe(null);
        result.FirstName.ShouldBe("John");
    }

    [Test]
    public async Task CreateStudent_ShouldAddStudent()
    {
        var student = new Student { Id = 1, FirstName = "John", LastName = "Doe" };

        await _mockStudentService.AddStudent(student, It.IsAny<CancellationToken>());

        _mockDbSet.Verify(m => m.AddAsync(student, default), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }

    [Test]
    public async Task UpdateStudentAsync_ShouldUpdateExistingStudent()
    {
        // Arrange
        var studentToUpdate = new Student { Id = 1, FirstName = "Jane", LastName = "Doe" };
        _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(studentToUpdate);
        
        // Act
        await _mockStudentService.UpdateStudent(studentToUpdate, CancellationToken.None);

        // Assert
        _mockDbSet.Verify(dbSet => dbSet.FindAsync(It.IsAny<int>()), Times.Once);
        _mockDbSet.Verify(dbSet => dbSet.Entry(studentToUpdate).CurrentValues.SetValues(It.IsAny<Student>()), Times.Once);
        _mockContext.Verify(ctx => ctx.SaveChangesAsync(default), Times.Once);
    }

    [Test]
    public async Task UpdateStudentAsync_ShouldThrowException_WhenStudentNotFound()
    {
        // Arrange
        var studentToUpdate = new Student { Id = 999, FirstName = "Jane", LastName = "Doe" };
        _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(studentToUpdate);

        // Act & Assert
        await Should.ThrowAsync<Exception>(() => _mockStudentService.UpdateStudent(studentToUpdate, It.IsAny<CancellationToken>()));
    }

    [Test]
    public async Task DeleteStudent_ShouldRemoveStudent()
    {
        // Arrange
        var student = new Student { Id = 1, FirstName = "John", LastName = "Doe" };
        _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(student);
        var cancellationToken = CancellationToken.None;

        // Act
        await _mockStudentService.DeleteStudent(student.Id, cancellationToken);

        // Assert
        _mockDbSet.Verify(m => m.Remove(student), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(cancellationToken), Times.Once);
    }
}

