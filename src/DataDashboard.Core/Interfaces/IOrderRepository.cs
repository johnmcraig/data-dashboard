using System.Collections.Generic;
using System.Threading.Tasks;
using DataDashboard.Core.Entities;

namespace DataDashboard.Core.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IList<Order>> ListAllWithPaging(int page, int pageSize);
    }
}