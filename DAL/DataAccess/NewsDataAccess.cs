using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public class NewsDataAccess : INewsDataAccess
    {
        private readonly IConfiguration _config;
        private string _environment = String.Empty;

        public NewsDataAccess(IConfiguration config)
        {
            _config = config;
            _environment = config.GetSection("Environment").Value;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
        {
            try
            {
                IDbConnection connection = new SqlConnection(_config.GetConnectionString(_environment));
                var Data = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return Data;

            }
            catch (Exception er)
            {

                throw;
            }
        }

        public async Task SaveData<T>(string storedProcedure, T parameters)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(_environment));
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
