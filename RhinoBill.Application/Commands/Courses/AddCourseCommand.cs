using MediatR;

namespace RhinoBill.Application;

public class AddCourseCommand : IRequest<AddCourseResponse>
{
    public AddCourseCommand()
    {
        
    }
    public CourseDto Course { get; set; }
}
