using DataDashboard.Core.Interfaces;

namespace DataDashboard.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(ICustomerRepository customerRepository, 
            IOrderRepository orderRepository, IServerRepository serverRepository)
        {
            Customers = customerRepository;
            Orders = orderRepository;
            Servers = serverRepository;
        }
        
        public IOrderRepository Orders { get; private set; }

        public ICustomerRepository Customers { get; private set;}

        public IServerRepository Servers { get; private set; }
    }
}