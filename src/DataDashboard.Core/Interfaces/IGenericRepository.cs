using System.Collections.Generic;
using System.Threading.Tasks;
using DataDashboard.Core.Entities;

namespace DataDashboard.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IList<T>> ListAllAsync();
        Task<T> GetByIdAsync(int id);  
    }
}