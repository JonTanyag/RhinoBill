using MediatR;
using Microsoft.AspNetCore.Mvc;
using RhinoBill.Application;

namespace RhinoBill;

[Route("api/v1/students")]
public class StudentController : Controller
{
    private readonly IMediator _mediatr;
    public StudentController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddStudentCommand command)
    {
        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediatr.Send(new GetStudentsQuery());
        return Ok(response);
    }
}
