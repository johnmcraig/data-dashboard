using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace DataDashboard.Infrastructure.Data
{
    public class OrderRepository : IGenericRepository<Order>
    {
        private readonly ILogger<OrderRepository> _logger;
        private readonly ISqlDataAccess _dataAccess;
        private const string ConnectionString = "default";

        public OrderRepository(ILogger<OrderRepository> logger, ISqlDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }
        
        public async Task<IList<Order>> ListAllAsync()
        {
            var query = @"SELECT * FROM dbo.Orders";
            
            try
            {
                var orders = await _dataAccess.
                    LoadData<Order, dynamic>(query, new { }, ConnectionString);
                return orders.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var query = @"SELECT * FROM dbo.Orders WHERE Id = @Id";
            try
            {
                var order = await _dataAccess.
                    LoadData<Order, dynamic>(query, new {Id = id}, ConnectionString);
                return order.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}