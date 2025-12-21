using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaglikAsistanim.API.Abstraction;
using SaglikAsistanim.Application.Features.BloodTests.Commands.CreateBloodTest;

namespace SaglikAsistanim.API.Controllers;


public sealed class BloodTestsController(IMediator mediator) : BaseApiController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> Create(
    CreateBloodTestCommand request,
    CancellationToken cancellationToken)
    => CreateActionResult(await _mediator.Send(request, cancellationToken));


 


}
