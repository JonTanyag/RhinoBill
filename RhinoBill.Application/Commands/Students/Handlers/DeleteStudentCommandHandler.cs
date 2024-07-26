using MediatR;
using Microsoft.Extensions.Logging;

namespace RhinoBill.Application;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, DeleteStudentResponse>
{
    private readonly IStudentService _studentService;
    private readonly ILogger<DeleteStudentCommandHandler> _logger;

    public DeleteStudentCommandHandler(IStudentService studentService, ILogger<DeleteStudentCommandHandler> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }
    public async Task<DeleteStudentResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _studentService.DeleteStudent(request.StudentId);

            _logger.LogInformation(ApiMessage.Delete_Student_LogInformation);
            return new DeleteStudentResponse(true, ApiMessage.Delete_Student_LogInformation, 200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Delete_Student_LogError + $"{ex.Message} - {ex.InnerException}");
            return new DeleteStudentResponse(false, ex.Message, 500);
        }
    }
}
