using MediatR;
using Microsoft.Extensions.Logging;

namespace RhinoBill.Application;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
{
    private readonly IStudentService _studentService;
    private readonly ILogger<GetStudentByIdQueryHandler> _logger;
    public GetStudentByIdQueryHandler(IStudentService studentService, ILogger<GetStudentByIdQueryHandler> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }
    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _studentService.GetStudentById(request.Id, cancellationToken);

        var student = new StudentDto
        {
            Id = result.Id,
            FirstName = result.FirstName,
            LastName = result.LastName,
            Birthday = result.Birthday,
            Email = result.Email,
            PhoneNumber = result.PhoneNumber,
            Courses = result.Courses.Select(x => new CourseDto{
                Id = x.Id,
                Title = x.Title,
                Code = x.Code,
                Credits = x.Credits,
            }).ToList()
        };
        return student;
    }
}
