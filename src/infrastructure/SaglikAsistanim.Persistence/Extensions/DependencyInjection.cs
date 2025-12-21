using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.BloodTests;
using SaglikAsistanim.Persistence.Context;
using SaglikAsistanim.Persistence.Measurements;
using SaglikAsistanim.Persistence.Options;
using SaglikAsistanim.Persistence.Users;

namespace SaglikAsistanim.Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceExt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionStrings = configuration
                .GetSection(ConnectionStringOption.Key)
                .Get<ConnectionStringOption>();


            options.UseSqlServer(connectionStrings!.SqlServer, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(PersistenceAssembly).Assembly.FullName);
            });
        });

        services.AddRepositories();

        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        //services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserHealthProfileRepository, UserHealthProfileRepository>();
        services.AddScoped<IBloodTestRepository,BloodTestRepository>();
        services.AddScoped<IMeasurementRepository, MeasurementRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
  
    }
}