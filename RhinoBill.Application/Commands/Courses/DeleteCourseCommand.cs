using MediatR;

namespace RhinoBill.Application;

public class DeleteCourseCommand : IRequest<DeleteCourseResponse>
{
    public DeleteCourseCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
