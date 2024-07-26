using MediatR;

namespace RhinoBill.Application;

public class UpdateCourseCommand : IRequest<UpdateCourseResponse>
{

    public CourseDto Course { get; set; }
}
