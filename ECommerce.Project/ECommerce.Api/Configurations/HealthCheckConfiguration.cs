using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ECommerce.Api.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static void AddHealthCheckConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringSql = configuration.GetConnectionString("ECommerceConnection");

            services.AddHealthChecks()
                    .AddSqlServer(connectionStringSql, tags: new[] { "sql-status" })
                    .AddCheck("api-status", () => HealthCheckResult.Healthy(), tags: new[] { "api-status" });
        }
    }
}
