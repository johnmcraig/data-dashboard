using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;

namespace DataDashboard.Infrastructure.Data
{
    internal class CustomerNpgsqlRepository : ICustomerRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        private const string ConnectionString = "default";

        public CustomerNpgsqlRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            //const string query = "SELECT * FROM \"public\".\"Customers\" " +
            //                     " WHERE \"Id\" = @Id";

            string sql = "dbo.spCustomer_GetById";

            try
            {
                var customer = await _dataAccess.LoadData<Customer, dynamic>
                    (sql, new
                    {
                        @Id = id
                    }, ConnectionString, true);

                return customer.FirstOrDefault();
            }
            catch (Exception ex) 
            { 
                throw new Exception($"There was an error retrieving a record: {ex}"); 
            }
        }

        public async Task<IList<Customer>> FindBySearch(string search)
        {
            string query = "SELECT * FROM \"public\".\"Customers\" " +
                           "WHERE \"Name\" ILIKE @Search";

            try
            {
                var result = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Search = "%" +  search + "%" 
                    }, ConnectionString, false);

                return result.ToList();
            }
            catch (Exception ex) { throw new Exception($"There was an error retrieving a record: {ex}"); }
        }

        public async Task<IList<Customer>> ListAllAsync()
        {
            const string query = "SELECT * FROM \"public\".\"Customers\" "; 

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new 
                    {
                    }, ConnectionString, false);

                return customers.ToList();
            }
            catch (Exception ex) 
            { 
                throw new Exception($"There was an error retrieving a record: {ex}"); 
            }
        }

        public async Task<IList<Customer>> ListAllWithPaging(int page, int pageSize)
        {

            const string query = "SELECT * FROM \"public\".\"Customers\" " +
                                 "OFFSET @Offset ROWS " +
                                 "FETCH NEXT @PageSize ROWS ONLY";

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Offset = (page - 1) * pageSize,
                        @PageSize = pageSize
                    }, ConnectionString);

                return customers.ToList();
            }
            catch (Exception ex) 
            { 
                throw new Exception($"There was an error retrieving a record: {ex}"); 
            }
        }

        public async Task<IList<Customer>> ListAllWithSearchingAndPaging(string search, int page, int pageSize)
        {

            const string query = "SELECT * FROM ( SELECT * FROM \"public\".\"Customers\" WHERE \"Name\" ILIKE  @Search ) Sub" +
                                 "ORDER BY \"Id\" OFFSET @Offset ROWS " +
                                 "FETCH NEXT @PageSize ROWS ONLY";

            try
            {
                var customers = await _dataAccess.LoadData<Customer, dynamic>
                    (query, new
                    {
                        @Search = "%" + search + "%",
                        @Offset = (page - 1) * pageSize,
                        @PageSize = pageSize
                    }, ConnectionString);

                return customers.ToList();
            }
            catch (Exception ex) 
            { 
                throw new Exception($"There was an error retrieving a record: {ex}"); 
            }
        }

        public async Task<Customer> Create(Customer entity)
        {
            const string query = "INSERT INTO \"public\".\"Customers\" " +
                                 "(\"Name\", \"Email\", \"State\") VALUES " + 
                                 "(@Name, @Email, @State);";
            try
            {
                var customer = new
                {
                    entity.Name,
                    entity.Email,
                    entity.State
                };
                    
                await _dataAccess.SaveData(query, customer, ConnectionString);

                return entity;
            }
            catch (Exception ex) 
            { 
                throw new Exception($"There was an error creating a record: {ex}"); 
            }
        }

        public async Task Delete(int id)
        {
            const string query = "DELETE FROM \"public\".\"Customers\" WHERE \"Id\" = @Id";

            try
            {
                await _dataAccess.SaveData(query, new { @Id = id }, ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error deleting the record: {ex}");
            }
        }

        public async Task Update(Customer customer)
        {
            const string query = "UPDATE \"public\".\"Customers\" SET \"Name\" = @Name, \"Email\" = @Email, \"State\" = @State WHERE \"Id\" = @Id";

            try
            {
                await _dataAccess.SaveData(query, customer, ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception($"There was an error updating the record: {ex}");
            }
        }
    }
}