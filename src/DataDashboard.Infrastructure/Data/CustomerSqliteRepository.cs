using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;
using DataDashboard.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataDashboard.Infrastructure.Data
{
    public class CustomerSqliteRepository : ICustomerRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        private readonly SqliteConnectionStringData _connectionString;

        public CustomerSqliteRepository(ISqlDataAccess dataAccess, SqliteConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            const string query = "SELECT Id, Name, Email, State FROM Customers" +
                                 " WHERE Id = @Id";
            try
            {
                var customer = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Id = id
                    }, _connectionString.ConnectionString, false);

                return customer.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error retrieving a record: {ex}");
            }
        }

        public async Task<IList<Customer>> FindBySearch(string search)
        {
            string query = "SELECT Id, Name, Email, State FROM Customers " +
                           "WHERE Name LIKE @Search";

            try
            {
                var result = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Search = "%" + search + "%"
                    }, _connectionString.ConnectionString, false);

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error retrieving a record: {ex}");
            }
        }

        public async Task<IList<Customer>> ListAllAsync()
        {
            const string query = "SELECT Id, Name, Email, State FROM Customers";

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                    }, _connectionString.ConnectionString, false);

                return customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error retrieving records: {ex}");
            }
        }

        public async Task<IList<Customer>> ListAllWithPaging(int page, int pageSize)
        {
            const string query = "SELECT Id, Name, Email, State FROM Customers " +
                                 "LIMIT @PageSize OFFSET @Offset; " +
                                 "SELECT COUNT(*) FROM Customers";

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Offset = (page - 1) * pageSize,
                        @PageSize = pageSize
                    }, _connectionString.ConnectionString, false);
                
                return customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error retrieving records: {ex}");
            }
        }

        public async Task<IList<Customer>> ListAllWithSearchingAndPaging(string search, int page, int pageSize)
        {
            const string query = "SELECT Id, Name, Email, State FROM Customers WHERE Name LIKE @Search " +
                                 "ORDER BY Id LIMIT @PageSize OFFSET @Offset";

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Search = "%" + search + "%",
                        @Offset = (page - 1) * pageSize,
                        @PageSize = pageSize
                    }, _connectionString.ConnectionString, false);

                return customers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error retrieving records: {ex}");
            }
        }

        public async Task<Customer> Create(Customer entity)
        {
            const string query = "INSERT INTO Customers " +
                                 "(Name, Email, State) VALUES " +
                                 "(@Name, @Email, @State);";
            try
            {
                var customer = new
                {
                    entity.Name,
                    entity.Email,
                    entity.State
                };

                await _dataAccess.SaveData(query, customer, _connectionString.ConnectionString, false);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error creating the record: {ex}");
            }
        }

        public async Task Delete(int id)
        {
            const string query = "DELETE FROM Customers WHERE Id = @Id";

            try
            {
                await _dataAccess.SaveData(query, new { @Id = id }, _connectionString.ConnectionString, false);
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error deleting the record: {ex}");
            }
        }

        public async Task Update(Customer customer)
        {
            const string query = "UPDATE Customers SET Name = @Name, Email = @Email, State = @State WHERE Id = @Id";

            try
            {
                await _dataAccess.SaveData(query, customer, _connectionString.ConnectionString, false);
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error updating the record: {ex}");
            }
        }
    }
}
