using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaglikAsistanim.API.Abstraction;
using SaglikAsistanim.Application.Features.HealthReports.Commands.CreateHealthReport;

namespace SaglikAsistanim.API.Controllers;


public class HealthReportsController(IMediator mediator) : BaseApiController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> Create(
 CreateHealthReportCommand request,
 CancellationToken cancellationToken)
 => CreateActionResult(await _mediator.Send(request, cancellationToken));
}
