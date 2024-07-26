using MediatR;
using Microsoft.Extensions.Logging;
using RhinoBill.Core;

namespace RhinoBill.Application;

public class GetApplicationQueryHandler : IRequestHandler<GetApplicationQuery, List<ApplicationDto>>
{
    private readonly IApplicationService _applicationService;
    private readonly ILogger<GetApplicationQueryHandler> _logger;
    public GetApplicationQueryHandler(IApplicationService applicationService, ILogger<GetApplicationQueryHandler> logger)
    {
        _applicationService = applicationService;
        _logger = logger;
    }
    public async Task<List<ApplicationDto>> Handle(GetApplicationQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var results = await _applicationService.GetApplications(cancellationToken);
            var applicationDto =  new List<ApplicationDto>();

            foreach (var result in results)
            {
                var application = new ApplicationDto
                {
                    Id = result.Id,
                    StudentId = result.StudentId,
                    StudentName = result.Students.FirstName + " " + result.Students.LastName,
                    CourseId = result.CourseId,
                    Course = result.Courses.Title,
                    ApplicationDate = result.ApplicationDate,
                };
                applicationDto.Add(application);
            }

            return applicationDto;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while getting data. " + ex.Message, ex);
            return new List<ApplicationDto>();
        }
    }
}
