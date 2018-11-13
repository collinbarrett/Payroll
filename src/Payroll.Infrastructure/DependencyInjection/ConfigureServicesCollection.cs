using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Payroll.Infrastructure.DependencyInjection
{
    public static class ConfigureServicesCollection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEntityFrameworkMySql()
                .AddDbContextPool<PayrollContext>(o =>
                    o.UseMySql(config.GetConnectionString("PayrollConnection")));
        }
    }
}