using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaglikAsistanim.API.Abstraction;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.CreateUserHealthProfile;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.DeleteUserProfile;

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(
     string id,
     CancellationToken cancellationToken)
    {
        var command = new DeleteUserHealthProfileCommand(id);

        return CreateActionResult(
            await _mediator.Send(command, cancellationToken)
        );
    }


}
