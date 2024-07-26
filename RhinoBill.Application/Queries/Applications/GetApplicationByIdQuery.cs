using MediatR;

namespace RhinoBill.Application;

public class GetApplicationByIdQuery : IRequest<ApplicationDto>
{
    public GetApplicationByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
