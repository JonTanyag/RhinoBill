using MediatR;
using Microsoft.Extensions.Logging;

namespace RhinoBill.Application;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto>
{
    private readonly ICourseService _courserService;
    private readonly ILogger<GetCourseByIdQueryHandler> _logger;
    public GetCourseByIdQueryHandler(ICourseService courserService, ILogger<GetCourseByIdQueryHandler> logger)
    {
        _courserService = courserService;
        _logger = logger;
    }
    public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _courserService.GetCourseById(request.Id);

            var courseDto = new CourseDto
            {
                Id = result.Id,
                Code = result.Code,
                Title = result.Title,
                Credits = result.Credits,
            };

            return courseDto;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while getting data. "+ ex.Message, ex);
            return new CourseDto();
        }
    }
}
