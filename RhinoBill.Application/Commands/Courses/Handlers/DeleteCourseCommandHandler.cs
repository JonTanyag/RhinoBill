using MediatR;
using Microsoft.Extensions.Logging;

namespace RhinoBill.Application;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeleteCourseResponse>
{
    private readonly ILogger<DeleteCourseCommandHandler> _logger;
    private readonly ICourseService _courseService;
    public DeleteCourseCommandHandler(ICourseService courseService,
        ILogger<DeleteCourseCommandHandler> logger)
    {
        _courseService = courseService;
        _logger = logger;
    }

    public async Task<DeleteCourseResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _courseService.DeleteCourse(request.Id);

            _logger.LogInformation(ApiMessage.Delete_Course_LogInformation);
            return new DeleteCourseResponse(true, ApiMessage.Delete_Course_LogInformation, 201);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Delete_Application_LogError + $"{ex.Message} - {ex.InnerException}");
            return new DeleteCourseResponse(false, ex.Message, 500);
        }
    }

}
