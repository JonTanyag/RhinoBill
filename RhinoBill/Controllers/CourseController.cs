using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RhinoBill;

[Route("api/v1/courses")]
public class CourseController : Controller
{
    private readonly IMediator _mediatr;

    public CourseController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }
}
