using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaglikAsistanim.API.Abstraction;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.CreateUserHealthProfile;

namespace SaglikAsistanim.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserHealthProfilesController : BaseApiController
{
    public UserHealthProfilesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(
    CreateUserHealthProfileCommand request,
    CancellationToken cancellationToken)
    => CreateActionResult(await _mediator.Send(request, cancellationToken));






}
