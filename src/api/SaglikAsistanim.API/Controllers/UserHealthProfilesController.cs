using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaglikAsistanim.API.Abstraction;
using SaglikAsistanim.API.Contracts.Requests;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.CreateUserHealthProfile;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.DeleteUserProfile;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Commands.UpdateUserHealthProfile;
using SaglikAsistanim.Application.Features.UserHealthProfiles.Queries.GetUserHealthProfileDetail;

namespace SaglikAsistanim.API.Controllers;


public sealed class UserHealthProfilesController(IMediator mediator) : BaseApiController(mediator)
{
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


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
       string id,
       [FromBody] UpdateUserHealthProfileRequest request,
       CancellationToken cancellationToken)
    {
        // Request + Route ID = Command
        var command = new UpdateUserHealthProfileCommand(
            Id: id,
            Weight: request.Weight,
            Height: request.Height,
            BloodType: request.BloodType,
            updateUserRequest:request.UpdateUserRequest
           
        );

        var result = await _mediator.Send(command, cancellationToken);
        return CreateActionResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
    string id,
    CancellationToken cancellationToken)
    {
        var query = new GetUserHealthProfileDetailQuery(id);

        var result = await _mediator.Send(query, cancellationToken);
        return CreateActionResult(result);
    }





}
