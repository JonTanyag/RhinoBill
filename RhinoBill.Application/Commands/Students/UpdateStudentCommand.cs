using MediatR;

namespace RhinoBill.Application;

public class UpdateStudentCommand : IRequest<UpdateStudentResponse>
{
    public UpdateStudentCommand()
    {
        
    }

    public StudentDto Student { get; set; }
}
