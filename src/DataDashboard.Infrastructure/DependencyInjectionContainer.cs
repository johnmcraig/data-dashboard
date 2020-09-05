using DataDashboard.Core;
using Microsoft.Extensions.DependencyInjection;
using DataDashboard.Infrastructure.Data;

namespace DataDashboard.Infrastructure
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // services.AddScoped<ISqlDataAccess, SqliteDataAccess>();
            services.AddDbContext<ApiContext>();

            // services.AddScoped<>();
            // services.AddScoped<>();
            // services.AddScoped<IUnitOfWork, UnitOfWork>();

            // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // services.AddSingleton<ILoggerService, LoggerService>();

            return services;
        }
    }
}
