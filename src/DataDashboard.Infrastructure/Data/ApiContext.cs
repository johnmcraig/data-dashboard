using DataDashboard.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataDashboard.Infrastructure.Data
{
    public class ApiContext : DbContext
    {
        private readonly IConfiguration _config;

        public ApiContext(DbContextOptions<ApiContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Server> Servers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseNpgsql(_config.GetConnectionString("secretConnectionString"));
            // optionsBuilder.UseSqlServer(_config.GetConnectionString("sqlConString"));
            // optionsBuilder.UseSqlite(_config.GetConnectionString("sqlite"));
        }
    }
}