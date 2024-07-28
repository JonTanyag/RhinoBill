using MediatR;
using Microsoft.AspNetCore.Mvc;
using RhinoBill.Application;

namespace RhinoBill;

[Route("api/applications")]
public class ApplicationController : Controller
{
    private readonly IMediator _mediatr;
    private readonly ApplicationValidator _validator;

    public ApplicationController(IMediator mediatr, ApplicationValidator validator)
    {
        _mediatr = mediatr;
        _validator = validator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddApplicationCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command.Application);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediatr.Send(new GetApplicationQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _mediatr.Send(new GetApplicationByIdQuery(id));
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateApplicationCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command.Application);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
            
        var response = await _mediatr.Send(command);
        return Ok(response);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _mediatr.Send(new DeleteApplicationCommand(id));
        return Ok(response);
    }
}
