using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Common.Database
{
    public static class SqlContext
    {
        public static IServiceCollection AddSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            // SQL Server Database
            //services.AddDbContextPool<ECommerceContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("ECommerceConnection")));

            return services;
        }
    }
}
