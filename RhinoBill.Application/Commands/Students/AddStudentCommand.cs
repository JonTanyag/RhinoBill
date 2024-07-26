using MediatR;

namespace RhinoBill.Application;

public class AddStudentCommand : IRequest<AddStudentResponse>
{
    public AddStudentCommand()
    {
        
    }
    public StudentDto Student { get; set; }
}
