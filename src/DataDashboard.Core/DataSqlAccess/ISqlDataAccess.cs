using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataDashboard.Core.DataSqlAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionStringName);
        Task SaveData<T>(string sql, T parameters, string connectionStringName);
    }
}