using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;

namespace DataDashboard.Infrastructure.Data
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        private const string ConnectionString = "default";

        public CustomerRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM \"public\".\"Customers\" WHERE \"Id\" = @Id";

            try
            {
                var customer = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        Id = id
                    }, ConnectionString);
                return customer.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Customer>> ListAllAsync()
        {
            var query = "SELECT * FROM \"public\".\"Customers\"";

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    { }, ConnectionString);
                return customers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}