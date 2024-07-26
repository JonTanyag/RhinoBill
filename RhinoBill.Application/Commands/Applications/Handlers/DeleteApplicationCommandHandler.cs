using MediatR;
using Microsoft.Extensions.Logging;
using RhinoBill.Core;

namespace RhinoBill.Application;

public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand, DeleteApplicationResponse>
{
    private readonly ILogger<DeleteApplicationCommandHandler> _logger;
    private readonly IApplicationService _applicationService;
    public DeleteApplicationCommandHandler(IApplicationService applicationService,
        ILogger<DeleteApplicationCommandHandler> logger)
    {
        _applicationService = applicationService;
        _logger = logger;
    }

    public async Task<DeleteApplicationResponse> Handle(DeleteApplicationCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _applicationService.DeleteApplication(request.Id);

            _logger.LogInformation(ApiMessage.Delete_Application_LogInformation);
            return new DeleteApplicationResponse(true, ApiMessage.Delete_Application_LogInformation, 201);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Delete_Application_LogError + $"{ex.Message} - {ex.InnerException}");
            return new DeleteApplicationResponse(false, ex.Message, 500);
        }
    }
}
