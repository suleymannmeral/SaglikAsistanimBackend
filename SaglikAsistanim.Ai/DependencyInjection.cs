
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaglikAsistanim.Application.Contracts.Ai;

namespace SaglikAsistanim.Ai;

public static class DependencyInjection
{
    public static IServiceCollection AddAiExt(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddScoped<IHealthReportAiAnalysisService, HealthReportAiAnalysisService>();
        services.AddScoped<IBloodTestAnalysisService, BloodTestAnalysisService>();


        return services;
    }
}
