using MediatR;

namespace SaglikAsistanim.Application.Features.HealthReports.Commands.CreateHealthReport;

public record CreateHealthReportCommand(string Prompt) : IRequest<ServiceResult<string>>;
