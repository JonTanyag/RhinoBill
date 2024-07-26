using Microsoft.EntityFrameworkCore;
using Moq;
using RhinoBill.Application;
using RhinoBill.Core;
using RhinoBill.Infrastructure;
using Shouldly;

namespace RhinoBill.UnitTest;

[TestFixture]
public class ApplicationServiceTests
{
    private Mock<RhinoBillDbContext> _mockContext;
    private Mock<DbSet<Core.Application>> _mockDbSet;
    private IApplicationService _applicationService;

    [SetUp]
    public void Setup()
    {
        _mockContext = new Mock<RhinoBillDbContext>(new DbContextOptions<RhinoBillDbContext>());
        _mockDbSet = new Mock<DbSet<Core.Application>>();
        _applicationService = new ApplicationService(_mockContext.Object);

        var applications = new List<Core.Application>
            {
                new Core.Application { Id = 1, StudentId = 1, CourseId = 1 },
                new Core.Application { Id = 2, StudentId = 2, CourseId = 2 }
            }.AsQueryable();

        _mockDbSet.As<IQueryable<Core.Application>>().Setup(m => m.Provider).Returns(applications.Provider);
        _mockDbSet.As<IQueryable<Core.Application>>().Setup(m => m.Expression).Returns(applications.Expression);
        _mockDbSet.As<IQueryable<Core.Application>>().Setup(m => m.ElementType).Returns(applications.ElementType);
        _mockDbSet.As<IQueryable<Core.Application>>().Setup(m => m.GetEnumerator()).Returns(applications.GetEnumerator());

        _mockContext.Setup(c => c.Applications).Returns(_mockDbSet.Object);
    }

    [Test]
    public async Task GetAllApplications_ShouldReturnAllApplications()
    {
        var result = await _applicationService.GetApplications(It.IsAny<CancellationToken>());

        result.ShouldNotBe(null);
        result.Count().ShouldBe(2);
        // result.First().StudentId.ShouldBe(1);
    }
    [Test]
    public async Task GetApplicationById_ShouldReturnApplication()
    {
        var application = new Core.Application { Id = 1, StudentId = 1, CourseId = 1 };
        _mockDbSet.Setup(m => m.FindAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(application);

        var result = await _applicationService.GetApplicationsById(1, It.IsAny<CancellationToken>());

        result.ShouldNotBe(null);
        result.StudentId.ShouldBe(1);
    }

    [Test]
    public async Task CreateApplication_ShouldAddApplication()
    {
        var application = new Core.Application { Id = 1, StudentId = 1, CourseId = 1 };

        await _applicationService.AddApplication(application, It.IsAny<CancellationToken>());

        _mockDbSet.Verify(m => m.AddAsync(application, default), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }

    [Test]
    public async Task UpdateApplication_ShouldUpdateApplication()
    {
        var application = new Core.Application { Id = 1, StudentId = 1, CourseId = 1 };
        _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(application);

        await _applicationService.UpdateApplication(application, It.IsAny<CancellationToken>());

        _mockDbSet.Verify(m => m.Update(application), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }

    [Test]
    public async Task DeleteApplication_ShouldRemoveApplication()
    {
        var application = new Core.Application { Id = 1, StudentId = 1, CourseId = 1 };
        _mockDbSet.Setup(m => m.FindAsync(1)).ReturnsAsync(application);

        await _applicationService.DeleteApplication(1, It.IsAny<CancellationToken>());

        _mockDbSet.Verify(m => m.Remove(application), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }
}
