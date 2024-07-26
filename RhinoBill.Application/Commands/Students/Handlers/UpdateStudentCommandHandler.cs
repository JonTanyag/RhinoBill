using MediatR;
using Microsoft.Extensions.Logging;
using RhinoBill.Core;

namespace RhinoBill.Application;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentResponse>
{
    private readonly IStudentService _studentService;
    private readonly ILogger<UpdateStudentCommandHandler> _logger;
    public UpdateStudentCommandHandler(IStudentService studentService, ILogger<UpdateStudentCommandHandler> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }

    public async Task<UpdateStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var student = new Student
            {
                FirstName = request.Student.FirstName,
                LastName = request.Student.LastName,
                Email = request.Student.Email,
                Birthday = request.Student.Birthday,
                PhoneNumber = request.Student.PhoneNumber,
            };

            await _studentService.UpdateStudent(student, cancellationToken);

             _logger.LogInformation(ApiMessage.Update_Student_LogInformation);
            return new UpdateStudentResponse(true, ApiMessage.Update_Student_LogInformation, 200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Update_Student_LogError + $"{ex.Message} - {ex.InnerException}");
            return new UpdateStudentResponse(false, ex.Message, 500);
        }
    }
}
