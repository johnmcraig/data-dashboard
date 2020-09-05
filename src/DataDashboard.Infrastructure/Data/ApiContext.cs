using DataDashboard.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataDashboard.Infrastructure.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        { }

        public DbSet<Customer> Customers
        {
            get;
            set;
        }
        public DbSet<Order> Orders
        {
            get;
            set;
        }
        public DbSet<Server> Servers
        {
            get;
            set;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_config.GetConnectionString("secretConnectionString"));
            // optionsBuilder.UseSqlServer(_config.GetConnectionString("sqlConString"));
            // optionsBuilder.UseSqlite(_config.GetConnectionString("sqlite"));
        }
    }
}