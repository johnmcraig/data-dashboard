using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataDashboard.Core.DataSqlAccess;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DataDashboard.Infrastructure.DataAccess
{
    public class NpgsqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public NpgsqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                var rows = await connection.QueryAsync<T>(sql, parameters, commandType: commandType);

                return rows.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters, string connectionStringName, bool isStoredProcedure = false)
        {
            CommandType commandType = CommandType.Text;

            if (isStoredProcedure == true)
            {
                commandType = CommandType.StoredProcedure;
            }

            using (IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionStringName)))
            {
                await connection.ExecuteAsync(sql, parameters, commandType: commandType);
            }
        }
    }
}