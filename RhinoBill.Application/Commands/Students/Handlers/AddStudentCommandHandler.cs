using MediatR;
using Microsoft.Extensions.Logging;

namespace RhinoBill.Application;

public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, AddStudentResponse>
{
    private readonly ILogger<AddStudentCommandHandler> _logger;
    public AddStudentCommandHandler(ILogger<AddStudentCommandHandler> logger)
    {
        _logger = logger;
    }

    public async Task<AddStudentResponse> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(ApiMessage.Add_Student_LogInformation);
            return new AddStudentResponse(true, ApiMessage.Add_Student_LogInformation, 200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Add_Student_LogError, $"{ex.Message} - {ex.InnerException}");
            return new AddStudentResponse(false, ex.Message, 500);
        }
    }
}
