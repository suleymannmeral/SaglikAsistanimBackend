namespace SaglikAsistanim.Application.Contracts.Ai;

public interface IBloodTestAnalysisService
{
    Task<ServiceResult<string>> AnalyzeAsync(string reportText);
}
