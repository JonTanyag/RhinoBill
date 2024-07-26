using MediatR;
using Microsoft.Extensions.Logging;
using RhinoBill.Core;

namespace RhinoBill.Application;

public class AddApplicationCommandHandler : IRequestHandler<AddApplicationCommand, AddApplicationResponse>
{
    private readonly ILogger<AddApplicationCommandHandler> _logger;
    private readonly IApplicationService _applicationService;
    public AddApplicationCommandHandler(IApplicationService applicationService,
        ILogger<AddApplicationCommandHandler> logger)
    {
        _applicationService = applicationService;
        _logger = logger;
    }

    public async Task<AddApplicationResponse> Handle(AddApplicationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var application = new Core.Application
            {
                Id = request.Application.Id,
                StudentId = request.Application.StudentId,
                CourseId = request.Application.CourseId,
                ApplicationDate = request.Application.ApplicationDate,
            };
            
            await _applicationService.AddApplication(application, cancellationToken);

            _logger.LogInformation(ApiMessage.Add_Application_LogInformation);
            return new AddApplicationResponse(true, ApiMessage.Add_Application_LogInformation, 201);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Add_Application_LogError, $"{ex.Message} - {ex.InnerException}");
            return new AddApplicationResponse(false, ex.Message, 500);
        }
    }
}
