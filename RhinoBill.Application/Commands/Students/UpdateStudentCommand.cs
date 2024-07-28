using MediatR;

namespace RhinoBill.Application;

public class UpdateStudentCommand : IRequest<UpdateStudentResponse>
{

    public StudentDto Student { get; set; }
}
