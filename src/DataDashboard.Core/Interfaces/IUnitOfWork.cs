using System;

namespace DataDashboard.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        ICustomerRepository Customers { get; }
    }
}