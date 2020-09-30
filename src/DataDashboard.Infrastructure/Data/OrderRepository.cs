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

        public OrderRepository(ISqlDataAccess dataAccess, IConfiguration config)
        {
            _config = config;
            _dataAccess = dataAccess;
        }

        public async Task<IList<Order>> ListAllAsync()
        {
            var query = @"SELECT o.*, cus.* FROM ""public"".""Orders"" AS o LEFT JOIN ""public"".""Customers"" AS cus ON o.""CustomerId"" = cus.""Id"" LIMIT 10";

            try
            {
                // var orders = await _dataAccess.
                // LoadData<Order, dynamic>(query, new
                // { }, ConnectionString);
                // return orders.ToList();
                using(var connection = new NpgsqlConnection(_config.GetConnectionString(ConnectionString)))
                {
                    connection.Open();
                    var resultList = await connection.QueryAsync<Order, Customer, Order>(query, (o, cus) =>
                        {
                            o.Customer = cus;
                            return o;
                        }, splitOn: "Id");
                    return resultList.ToList();
                }
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