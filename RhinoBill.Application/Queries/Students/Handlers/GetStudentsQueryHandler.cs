using MediatR;
using Microsoft.Extensions.Logging;

namespace RhinoBill.Application;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentDto>>
{
    private readonly IStudentService _studentService;
    private readonly ILogger<GetStudentsQueryHandler> _logger;
    public GetStudentsQueryHandler(IStudentService studentService, ILogger<GetStudentsQueryHandler> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }
    public async Task<List<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var results = await _studentService.GetStudents();
        var studentDto = new List<StudentDto>();

        foreach (var item in results)
        {
            var student = new StudentDto
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Birthday = item.Birthday,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
            };
            studentDto.Add(student);
        }

        return studentDto;
    }
}
