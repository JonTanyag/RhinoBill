using MediatR;

namespace RhinoBill.Application;

public class AddApplicationCommand : IRequest<AddApplicationResponse>
{
    public AddApplicationCommand()
    {

    }
    public ApplicationDto Application { get; set; }
}
