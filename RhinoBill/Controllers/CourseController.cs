using MediatR;
using Microsoft.AspNetCore.Mvc;
using RhinoBill.Application;

namespace RhinoBill;

[Route("api/v1/courses")]
public class CourseController : Controller
{
    private readonly IMediator _mediatr;

    public CourseController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddCourseCommand command)
    {
        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediatr.Send(new GetCourseQuery());
        return Ok(response);
    }
}
