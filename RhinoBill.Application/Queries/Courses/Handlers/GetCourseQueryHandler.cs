using MediatR;
using Microsoft.Extensions.Logging;

namespace RhinoBill.Application;

public class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, List<CourseDto>>
{
    private readonly ICourseService _courserService;
    private readonly ILogger<GetCourseQueryHandler> _logger;
    public GetCourseQueryHandler(ICourseService courserService, ILogger<GetCourseQueryHandler> logger)
    {
        _courserService = courserService;
        _logger = logger;
    }
    public async Task<List<CourseDto>> Handle(GetCourseQuery request, CancellationToken cancellationToken)
    {
        var results = await _courserService.GetCourses();
        var courseDto = new List<CourseDto>();

        foreach (var item in results)
        {
            var course = new CourseDto
            {
                Id = item.Id,
                Code = item.Code,
                Title = item.Title,
                Credits = item.Credits,
            };
            courseDto.Add(course);
        }

        return courseDto;
    }
}
