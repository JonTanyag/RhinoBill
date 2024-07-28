using MediatR;
using Microsoft.Extensions.Logging;
using RhinoBill.Core;

namespace RhinoBill.Application;

public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, AddStudentResponse>
{
    private readonly ILogger<AddStudentCommandHandler> _logger;
    private readonly IStudentService _studentService;
    private readonly RandomGenerator _randomGenerator;
    public AddStudentCommandHandler(IStudentService studentService, 
        ILogger<AddStudentCommandHandler> logger,
        RandomGenerator randomGenerator)
    {
        _studentService = studentService;
        _randomGenerator = randomGenerator;
        _logger = logger;
    }

    public async Task<AddStudentResponse> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Student payload: "+ request);
            var student = new Student
            {
                Id = _randomGenerator.GenerateId(), //request.Student.Id,
                FirstName = request.Student.FirstName,
                LastName = request.Student.LastName,
                Birthday = request.Student.Birthday,
                Email = request.Student.Email,
                PhoneNumber = request.Student.PhoneNumber,
            };
            
            await _studentService.AddStudent(student, cancellationToken);

            _logger.LogInformation(ApiMessage.Add_Student_LogInformation);
            return new AddStudentResponse(true, ApiMessage.Add_Student_LogInformation, 200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Add_Student_LogError + $"{ex.Message} - {ex.InnerException}");
            return new AddStudentResponse(false, ex.Message, 500);
        }
    }
}
