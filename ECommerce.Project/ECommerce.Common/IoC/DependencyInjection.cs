using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Common.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            // Repository
            //services.AddScoped(typeof(IRepository<>), typeof(RepositoryStandard<>));
            //services.AddScoped<IUnitOfWork, UnitOfWorkStandard>();


            // Services
            //services.AddScoped<ICustomerService, CustomerService>();

            // Adapters
            //services.AddScoped<AuthServerAuthenticationAdapter>();
            //services.AddScoped<Func<AuthenticationSystem, IAuthenticationAdapter>>(
            //        serviceProvider => authenticationType =>
            //        {
            //            switch (authenticationType)
            //            {
            //                case AuthenticationSystem.Identity:
            //                    return serviceProvider.GetRequiredService<IdentityServerAuthenticationAdapter>();
            //                case AuthenticationSystem.Auth:
            //                    return serviceProvider.GetRequiredService<AuthServerAuthenticationAdapter>();
            //                default:
            //                    throw new InvalidOperationException("Authentication type not implemented");
            //            }
            //        });

            // Seeds
            //services.AddScoped<IDbInitializer, DbInitializer>();

            return services;
        }
    }
}
