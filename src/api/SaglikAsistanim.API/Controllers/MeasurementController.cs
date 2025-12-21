using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaglikAsistanim.API.Abstraction;
using SaglikAsistanim.Application.Features.Measurements.Commands.CreateMeasurement;

namespace SaglikAsistanim.API.Controllers;


public class MeasurementController(IMediator mediator) : BaseApiController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> Create(
  CreateMeasurementCommand request,
  CancellationToken cancellationToken)
  => CreateActionResult(await _mediator.Send(request, cancellationToken));


}
