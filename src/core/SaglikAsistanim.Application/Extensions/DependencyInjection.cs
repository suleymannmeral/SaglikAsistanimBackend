using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SaglikAsistanim.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationExt(this IServiceCollection services)
    {
        MediatrExt(services);
        return services;
    }

    public static IServiceCollection MediatrExt(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
        );

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}
