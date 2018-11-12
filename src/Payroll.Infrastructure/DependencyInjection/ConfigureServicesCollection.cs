using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Payroll.Infrastructure.DependencyInjection
{
    public static class ConfigureServicesCollection
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            const string connection = "Data Source=payroll.db";
            services.AddDbContextPool<PayrollContext>(options => options.UseSqlite(connection));
        }
    }
}