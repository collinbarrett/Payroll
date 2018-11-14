using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Payroll.Infrastructure.Services;

namespace Payroll.Infrastructure.DependencyInjection
{
    public static class ConfigureServicesCollection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEntityFrameworkMySql()
                    .AddDbContextPool<PayrollDbContext>(o =>
                        o.UseMySql(config.GetConnectionString("PayrollConnection")));
            services.TryAddScoped<EmployeeManager>();
        }
    }
}