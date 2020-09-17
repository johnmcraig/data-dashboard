using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            Customers = customerRepository;
            Orders = orderRepository;
        }
        
        public IOrderRepository Orders { get; private set; }

        public ICustomerRepository Customers { get; private set;}
    }
}