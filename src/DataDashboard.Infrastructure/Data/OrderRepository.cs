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
    public class OrderRepository : IOrderRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        private const string ConnectionString = "default";

        public OrderRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IList<Order>> ListAllAsync()
        {
            //DELCARE @PageSize int DECLARE @PageNumber int SET @PageSize = 25 SET @PageNumber = 2 ORDER BY Completed OFFEST @PageSize * (@PageNumber - 1) ROWS FETCH NEXT @PageSize ROWS ONLY
            var query = @"SELECT o.*, cus.""Name"" FROM ""public"".""Orders"" AS o LEFT JOIN ""public"".""Customers"" AS cus ON o.""CustomerId"" = cus.""Id"" SELECT * FROM ""public"".""Customers"" WHERE ""Id"" = @Id";

            try
            {
                var orders = await _dataAccess.
                LoadData<Order, dynamic>(query, new
                { }, ConnectionString);
                return orders.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var query = @"SELECT * FROM ""public"".""Orders"" WHERE ""Id"" = @Id";
            try
            {
                var order = await _dataAccess.
                LoadData<Order, dynamic>(query, new
                {
                    Id = id
                }, ConnectionString);
                return order.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}