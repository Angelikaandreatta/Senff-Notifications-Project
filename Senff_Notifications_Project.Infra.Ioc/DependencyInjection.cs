using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Senff_Notifications_Project.Application.Mappings;
using Senff_Notifications_Project.Application.Services;
using Senff_Notifications_Project.Application.Services.Interfaces;
using Senff_Notifications_Project.Domain.Repositories;
using Senff_Notifications_Project.Infra.Data.Context;
using Senff_Notifications_Project.Infra.Data.Repositories;

namespace Senff_Notifications_Project.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("myconnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ModelToDtoMapping));
            services.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
            return services;
        }
    }
}
