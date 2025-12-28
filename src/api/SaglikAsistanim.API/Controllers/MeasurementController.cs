using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaglikAsistanim.API.Abstraction;
using SaglikAsistanim.API.Contracts.Requests;
using SaglikAsistanim.Application.Features.Measurements.Commands.CreateMeasurement;
using SaglikAsistanim.Application.Features.Measurements.Commands.DeleteMeasurement;
using SaglikAsistanim.Application.Features.Measurements.Commands.UpdateMeasurement;

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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
     int id,
     [FromBody] UpdateMeasurementRequest request,
     CancellationToken cancellationToken)
    {
        // Request + Route ID = Command
        var command = new UpdateMeasurementCommand(
            Id: id,
            Type:request.Type,
            Value1:request.Value1,
            Value2:request.Value2,
            Unit:request.Unit,
            MeasuredAt:request.MeasuredAt,
            Notes:request.Notes

        );

        var result = await _mediator.Send(command, cancellationToken);
        return CreateActionResult(result);
    }




}
