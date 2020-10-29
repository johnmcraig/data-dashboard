using DataDashboard.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using DataDashboard.Infrastructure.Data;
using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Infrastructure.DataAccess;
using DataDashboard.Infrastructure.SeedData;

namespace DataDashboard.Infrastructure
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISqlDataAccess, SqliteDataAccess>();
            services.AddDbContext<ApiContext>();

            services.AddTransient<DataSeed>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IOrderRepository, OrderSqliteRepository>();
            services.AddScoped<ICustomerRepository, CustomerSqliteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
