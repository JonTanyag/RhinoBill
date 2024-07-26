using MediatR;
using Microsoft.Extensions.Logging;
using RhinoBill.Core;

namespace RhinoBill.Application;

public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, UpdateApplicationResponse>
{
    private readonly ILogger<UpdateApplicationCommandHandler> _logger;
    private readonly IApplicationService _applicationService;
    public UpdateApplicationCommandHandler(IApplicationService applicationService,
        ILogger<UpdateApplicationCommandHandler> logger)
    {
        _applicationService = applicationService;
        _logger = logger;
    }

    public async Task<UpdateApplicationResponse> Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
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
            
            await _applicationService.UpdateApplication(application);

            _logger.LogInformation(ApiMessage.Update_Application_LogInformation);
            return new UpdateApplicationResponse(true, ApiMessage.Update_Application_LogInformation, 201);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Update_Application_LogError + $"{ex.Message} - {ex.InnerException}");
            return new UpdateApplicationResponse(false, ex.Message, 500);
        }
    }
}
