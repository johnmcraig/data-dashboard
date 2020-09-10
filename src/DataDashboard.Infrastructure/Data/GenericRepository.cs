using System.Collections.Generic;
using System.Threading.Tasks;
using DataDashboard.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataDashboard.Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApiContext _context;

        public GenericRepository(ApiContext context)
        {
            _context = context;
        }
        
        public async Task<IList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}