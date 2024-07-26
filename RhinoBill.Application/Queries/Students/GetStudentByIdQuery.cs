using MediatR;

namespace RhinoBill.Application;

public class GetStudentByIdQuery : IRequest<StudentDto>
{
    public GetStudentByIdQuery(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}
