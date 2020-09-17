using DataDashboard.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using DataDashboard.Infrastructure.Data;
using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Infrastructure.DataAccess;

namespace DataDashboard.Infrastructure
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ISqlDataAccess, SqlDataAccess>();
            services.AddDbContext<ApiContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
