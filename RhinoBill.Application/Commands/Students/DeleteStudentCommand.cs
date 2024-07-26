using MediatR;

namespace RhinoBill.Application;

public class DeleteStudentCommand : IRequest<DeleteStudentResponse>
{
    public DeleteStudentCommand(int studentId)
    {
        StudentId = studentId;
    }

    public int StudentId { get; set; }
}
