using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DataDashboard.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        private const string ConnectionString = "default";
        private readonly IConfiguration _config;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(ISqlDataAccess dataAccess, 
            IConfiguration config,
            ILogger<OrderRepository> logger)
        {
            _config = config;
            _logger = logger;
            _dataAccess = dataAccess;
        }

        public async Task<IList<Order>> ListAllAsync()
        {
            int page = 1;
            int pageSize = 10;

            var query = "SELECT o.*, cus.* FROM \"public\".\"Orders\" AS o " +
                        "LEFT JOIN \"public\".\"Customers\" AS cus " +
                        "ON o.\"CustomerId\" = cus.\"Id\" " +
                        "ORDER BY o.\"Id\"" +
                        "OFFSET @Offset ROWS " +
                        "FETCH NEXT @PageSize ROWS ONLY";

            try
            {
                using (var connection = new NpgsqlConnection(_config
                    .GetConnectionString(ConnectionString)))
                {
                    connection.Open();

                    var resultList = await connection.QueryAsync<Order, Customer, Order>
                        (query, (o, cus) =>
                        {
                            o.Customer = cus;
                            return o;
                        },
                        new 
                        {
                            Offset = (page - 1) * pageSize,
                            PageSize = pageSize
                        }, splitOn: "Id");

                    return resultList.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error:{ex}");
                throw;
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var query = "SELECT o.\"Id\", o.\"CustomerId\", o.\"Placed\", o.\"Completed\"," +
                        " o.\"Total\", cus.\"Id\", cus.\"Name\""+
                        "FROM \"public\".\"Orders\" AS o " +
                        "INNER JOIN \"public\".\"Customers\" AS cus " +
                        "ON o.\"CustomerId\" = cus.\"Id\" " +
                        "WHERE o.\"Id\" = @Id";
            try
            {
                using (var connection = new NpgsqlConnection(_config
                    .GetConnectionString(ConnectionString)))
                {
                    connection.Open();

                    var orders = await connection.QueryAsync<Order, Customer, Order>
                        (query, (order, customer) =>
                        {
                            order.Customer = customer;
                            return order;
                        }, 
                        new 
                        { 
                            @Id = id
                        }, splitOn: "Id");

                    return orders.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error:{ex}");
                throw;
            }
        }
    }
}