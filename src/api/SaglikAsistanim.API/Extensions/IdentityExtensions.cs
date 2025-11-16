using SaglikAsistanim.Identity.Models;
using SaglikAsistanim.Persistence.Context;

namespace SaglikAsistanim.API.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityExt(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, Role>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<AppDbContext>();
        

        return services;
    }

}
