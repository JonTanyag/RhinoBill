using MediatR;
using Microsoft.AspNetCore.Mvc;
using RhinoBill.Application;

namespace RhinoBill;

[Route("api/courses")]
public class CourseController : Controller
{
    private readonly IMediator _mediatr;
    private readonly CourseValidator _validator;
    public CourseController(IMediator mediatr, CourseValidator validator)
    {
        _mediatr = mediatr;
        _validator = validator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddCourseCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command.Course);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediatr.Send(new GetCourseQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _mediatr.Send(new GetCourseByIdQuery(id));
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateCourseCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command.Course);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _mediatr.Send(new DeleteCourseCommand(id));
        return Ok(response);
    }
}
