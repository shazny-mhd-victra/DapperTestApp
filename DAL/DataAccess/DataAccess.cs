using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DAL.DataAccess
{
    public class DataAccess<T> : IDataAccess<T> where T : class
    {
        private readonly IConfiguration _config;
        private string _environment = String.Empty;

        public DataAccess(IConfiguration config)
        {
            _config = config;
            _environment = config.GetSection("Environment").Value;
        }

        public async Task<IEnumerable<T>> LoadData<S, U>(string storedProcedure, U parameters)
        {
            IDbConnection connection = new SqlConnection(_config.GetConnectionString(_environment));
            var Data = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

            return Data;
        }

        public async Task SaveData<U>(string storedProcedure, U parameters)
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(_environment));
            connection.Open();
            var trans = connection.BeginTransaction();
            try
            {
                var Data = await connection.ExecuteAsync(storedProcedure, parameters,trans, commandType: CommandType.StoredProcedure);
                trans.Commit();
            }
            catch (Exception er)
            {
                trans.Rollback();
                Console.WriteLine(er.Message);
                throw;
            }
            finally
            {
                connection.Close();

            }
        }

 


















        //public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
        //{
        //    IDbConnection connection = new SqlConnection(_config.GetConnectionString(_environment));
        //    var Data = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        //    return Data;
        //}

        //public async Task SaveData<T>(string storedProcedure, T parameters)
        //{
        //    using IDbConnection connection = new SqlConnection(_config.GetConnectionString(_environment));
        //    var Data = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        //    connection.Close();

        //}
    }
}
