using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaglikAsistanim.API.Abstraction;
using SaglikAsistanim.Application.Features.Measurements.Commands.CreateMeasurement;
using SaglikAsistanim.Application.Features.Measurements.Commands.DeleteMeasurement;

namespace SaglikAsistanim.API.Controllers;


public class MeasurementController(IMediator mediator) : BaseApiController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> Create(
  CreateMeasurementCommand request,
  CancellationToken cancellationToken)
  => CreateActionResult(await _mediator.Send(request, cancellationToken));


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(
   int id,
   CancellationToken cancellationToken)
    {
        var command = new DeleteMeasurementCommand(id);

        return CreateActionResult(
            await _mediator.Send(command, cancellationToken)
        );
    }

}
