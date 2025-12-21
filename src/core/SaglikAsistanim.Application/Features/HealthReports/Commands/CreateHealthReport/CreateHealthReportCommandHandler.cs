using MediatR;
using SaglikAsistanim.Application.Contracts.Ai;

namespace SaglikAsistanim.Application.Features.HealthReports.Commands.CreateHealthReport;

public sealed class CreateHealthReportCommandHandler(IHealthReportAiAnalysisService aiService)
    : IRequestHandler<CreateHealthReportCommand, ServiceResult<string>>
{
    public  async Task<ServiceResult<string>> Handle(CreateHealthReportCommand request, CancellationToken cancellationToken)
    {
        var report = await aiService.CreateReportAsync(request.Prompt);

        return ServiceResult<string>.Success(report.Data!);
    }
}
