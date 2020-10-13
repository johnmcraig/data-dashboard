using DataDashboard.Core.Entities;
using System.Threading.Tasks;

namespace DataDashboard.Core.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> Create(Customer entity);
    }
}