using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaglikAsistanim.Application;
using System.Net;

namespace SaglikAsistanim.API.Abstraction;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseApiController : ControllerBase
{
    public readonly IMediator _mediator;

    protected BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.Created => Created(result.UrlAsCreated, result),
            _ => new ObjectResult(result) { StatusCode = (int)result.StatusCode }
        };
    }

    [NonAction]
    public IActionResult CreateActionResult(ServiceResult result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.NoContent => new ObjectResult(null) { StatusCode = (int)result.StatusCode },
            _ => new ObjectResult(result) { StatusCode = (int)result.StatusCode }
        };
    }


}
