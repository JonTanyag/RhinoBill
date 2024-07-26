using MediatR;
using Microsoft.Extensions.Logging;

namespace RhinoBill.Application;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentResponse>
{
    private readonly ILogger<UpdateStudentCommandHandler> _logger;
    public UpdateStudentCommandHandler(ILogger<UpdateStudentCommandHandler> logger)
    {
        _logger = logger;
    }

    public async Task<UpdateStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
             _logger.LogInformation(ApiMessage.Update_Student_LogInformation);
            return new UpdateStudentResponse(true, ApiMessage.Update_Student_LogInformation, 200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Update_Student_LogError, $"{ex.Message} - {ex.InnerException}");
            return new UpdateStudentResponse(false, ex.Message, 500);
        }
    }
}
