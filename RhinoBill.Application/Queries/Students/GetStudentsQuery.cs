using MediatR;

namespace RhinoBill.Application;

public class GetStudentsQuery : IRequest<List<StudentDto>>
{
    public GetStudentsQuery()
    {

    }
}
