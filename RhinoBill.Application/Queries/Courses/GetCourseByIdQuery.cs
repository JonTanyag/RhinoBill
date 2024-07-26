using MediatR;

namespace RhinoBill.Application;

public class GetCourseByIdQuery : IRequest<CourseDto>
{
    public GetCourseByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
