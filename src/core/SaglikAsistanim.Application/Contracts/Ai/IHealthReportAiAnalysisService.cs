namespace SaglikAsistanim.Application.Contracts.Ai;

public interface IHealthReportAiAnalysisService
{
    Task<ServiceResult<string>> CreateReportAsync(string reportText);


}
