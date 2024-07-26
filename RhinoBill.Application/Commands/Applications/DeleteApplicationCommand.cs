using MediatR;

namespace RhinoBill.Application;

public class DeleteApplicationCommand : IRequest<DeleteApplicationResponse>
{
    public DeleteApplicationCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
