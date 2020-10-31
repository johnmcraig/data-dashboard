using DataDashboard.Core.DataSqlAccess;
using DataDashboard.Core.Entities;
using DataDashboard.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataDashboard.Infrastructure.Data
{
    public class ServerSqliteRepository : IServerRepository
    {
        private readonly ISqlDataAccess _dataAccess;
        private const string ConnectionString = "sqlite";

        public ServerSqliteRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Server> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Servers WHERE Id = @Id";

            try
            {
                var server = await _dataAccess.LoadData<Server, dynamic>(sql, 
                    new { @Id = id }, ConnectionString);

                return server.SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IList<Server>> ListAllAsync()
        {
            string sql = "SELECT * FROM Servers";

            try
            {
                var servers = await _dataAccess.LoadData<Server, dynamic>(sql, 
                    new { }, ConnectionString);

                return servers.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
