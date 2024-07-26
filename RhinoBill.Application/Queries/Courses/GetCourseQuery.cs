using MediatR;

namespace RhinoBill.Application;

public class GetCourseQuery: IRequest<List<CourseDto>>
{
    public GetCourseQuery()
    {

    }
}
