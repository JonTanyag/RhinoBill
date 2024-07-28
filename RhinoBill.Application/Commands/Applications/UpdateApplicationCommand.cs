using MediatR;

namespace RhinoBill.Application;

public class UpdateApplicationCommand : IRequest<UpdateApplicationResponse>
{
    public ApplicationDto Application { get; set; }
}
