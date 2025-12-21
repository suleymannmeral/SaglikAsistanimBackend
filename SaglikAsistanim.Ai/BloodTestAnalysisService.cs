using SaglikAsistanim.Application;
using SaglikAsistanim.Application.Contracts.Ai;

namespace SaglikAsistanim.Ai;

public sealed class BloodTestAnalysisService : IBloodTestAnalysisService
{
    public Task<ServiceResult<string>> AnalyzeAsync(string reportText)
    {
        throw new NotImplementedException();
    }
}
