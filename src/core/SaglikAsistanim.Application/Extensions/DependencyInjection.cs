using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SaglikAsistanim.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationExt(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );


        return services;
    }
}
