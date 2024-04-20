using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Senff_Notifications_Project.Infra.Data.Context;

namespace Senff_Notifications_Project.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("myconnection")));

            return services;
        }
    }
}
