using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RhinoBill;

[Route("api/v1/applications")]
public class ApplicationController : Controller
{
    private readonly IMediator _mediatr;

    public ApplicationController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }
}
