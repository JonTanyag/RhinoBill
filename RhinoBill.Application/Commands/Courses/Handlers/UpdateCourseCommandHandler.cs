using MediatR;
using Microsoft.Extensions.Logging;
using RhinoBill.Core;

namespace RhinoBill.Application;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, UpdateCourseResponse>
{
    private readonly ILogger<UpdateCourseCommandHandler> _logger;
    private readonly ICourseService _courseService;
    public UpdateCourseCommandHandler(ICourseService courseService,
        ILogger<UpdateCourseCommandHandler> logger)
    {
        _courseService = courseService;
        _logger = logger;
    }

    public async Task<UpdateCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var course = new Course
            {
                Id = request.Course.Id,
                Code = request.Course.Code,
                Title = request.Course.Title,
                Credits = request.Course.Credits,
            };
            
            await _courseService.UpdateCourse(course);

            _logger.LogInformation(ApiMessage.Add_Course_LogInformation);
            return new UpdateCourseResponse(true, ApiMessage.Add_Course_LogInformation, 201);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Add_Course_LogError, $"{ex.Message} - {ex.InnerException}");
            return new UpdateCourseResponse(false, ex.Message, 500);
        }
    }
}
