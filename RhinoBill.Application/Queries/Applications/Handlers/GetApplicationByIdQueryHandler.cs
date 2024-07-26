using MediatR;
using Microsoft.Extensions.Logging;
using RhinoBill.Core;

namespace RhinoBill.Application;

public class GetApplicationByIdQueryHandler : IRequestHandler<GetApplicationByIdQuery, ApplicationDto>
{
    private readonly IApplicationService _applicationService;
    private readonly ILogger<GetApplicationByIdQueryHandler> _logger;
    public GetApplicationByIdQueryHandler(IApplicationService applicationService, ILogger<GetApplicationByIdQueryHandler> logger)
    {
        _applicationService = applicationService;
        _logger = logger;
    }
    public async Task<ApplicationDto> Handle(GetApplicationByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _applicationService.GetApplicationsById(request.Id, cancellationToken);

            var courseDto = new ApplicationDto
            {
                Id = result.Id,
                StudentId = result.StudentId,
                StudentName = result.Students.FirstName + " " + result.Students.LastName,
                CourseId = result.CourseId,
                Course = result.Courses.Title,
                ApplicationDate = result.ApplicationDate,
            };

            return courseDto;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while getting data. " + ex.Message, ex);
            return new ApplicationDto();
        }
    }
}
