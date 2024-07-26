using MediatR;

namespace RhinoBill.Application;

public class UpdateApplicationCommand : IRequest<UpdateApplicationResponse>
{
    public UpdateApplicationCommand()
    {

    }
    public ApplicationDto Application { get; set; }
}
