using Microsoft.EntityFrameworkCore;
using Moq;
using RhinoBill.Application;
using RhinoBill.Core;
using RhinoBill.Infrastructure;
using Shouldly;

namespace RhinoBill.UnitTest;

[TestFixture]
public class CourseServiceTests
{
    private Mock<RhinoBillDbContext> _mockContext;
    private Mock<DbSet<Course>> _mockDbSet;
    private ICourseService _courseService;

    [SetUp]
    public void Setup()
    {
        _mockContext = new Mock<RhinoBillDbContext>(new DbContextOptions<RhinoBillDbContext>());
        _mockDbSet = new Mock<DbSet<Course>>();
        _courseService = new CourseService(_mockContext.Object);

        var courses = new List<Course>
            {
                new Course { Id = 1, Code = "CS101", Title = "Computer Science", Credits = 3 },
                new Course { Id = 2, Code = "MATH101", Title = "Mathematics", Credits = 3 }
            }.AsQueryable();

        _mockDbSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(courses.Provider);
        _mockDbSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(courses.Expression);
        _mockDbSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(courses.ElementType);
        _mockDbSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(courses.GetEnumerator());

        _mockContext.Setup(c => c.Courses).Returns(_mockDbSet.Object);
    }

    [Test]
    public async Task GetAllCourses_ShouldReturnAllCourses()
    {
        var result = await _courseService.GetCourses(It.IsAny<CancellationToken>());

        result.ShouldNotBe(null);
        result.Count().ShouldBe(2);
        // result.First().Code.ShouldBe("CS101");
    }

    [Test]
    public async Task GetCourseById_ShouldReturnCourse()
    {
        var course = new Course { Id = 1, Code = "CS101", Title = "Computer Science", Credits = 3 };
        _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(course);

        var result = await _courseService.GetCourseById(1, It.IsAny<CancellationToken>());

        result.ShouldNotBe(null);
        result.Code.ShouldBe("CS101");
    }

    [Test]
    public async Task CreateCourse_ShouldAddCourse()
    {
        var course = new Course { Id = 1, Code = "CS101", Title = "Computer Science", Credits = 3 };

        await _courseService.AddCourse(course, It.IsAny<CancellationToken>());

        _mockDbSet.Verify(m => m.AddAsync(course, It.IsAny<CancellationToken>()), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateCourse_ShouldUpdateCourse()
    {
        var course = new Course { Id = 1, Code = "CS101", Title = "Computer Science", Credits = 3 };
        _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(course);
        
        await _courseService.UpdateCourse(course, It.IsAny<CancellationToken>());

        _mockDbSet.Verify(m => m.Update(course), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DeleteCourse_ShouldRemoveCourse()
    {
        var course = new Course { Id = 1, Code = "CS101", Title = "Computer Science", Credits = 3 };
        _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(course);

        await _courseService.DeleteCourse(1, It.IsAny<CancellationToken>());

        _mockDbSet.Verify(m => m.Remove(course), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }
}
