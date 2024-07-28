using MediatR;
using Microsoft.AspNetCore.Mvc;
using RhinoBill.Application;

namespace RhinoBill;

[Route("api/students")]
public class StudentController : Controller
{
    private readonly IMediator _mediatr;
    private readonly StudentValidator _validator;
    public StudentController(IMediator mediatr, StudentValidator validator)
    {
        _mediatr = mediatr;
        _validator = validator;
    }

    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediatr.Send(new GetStudentsQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _mediatr.Send(new GetStudentByIdQuery(id));
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddStudentCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command.Student);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateStudentCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command.Student);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
            
        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _mediatr.Send(new DeleteStudentCommand(id));
        return Ok(response);
    }

}
