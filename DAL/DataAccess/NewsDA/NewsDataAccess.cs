using DAL.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess.NewsDA
{
    public class NewsDataAccess : DataAccess<News>, INewsDataAccess
    {
        private readonly IConfiguration _config;
        private string _environment = string.Empty;
        
        public NewsDataAccess(IConfiguration config) : base(config)
        {
            _config = config;
            _environment = config.GetSection("Environment").Value;
        }

        public async Task<IEnumerable<News>> GetData<T,U>(string storedProcedure,U parameters)
        {
            IDbConnection connection = new SqlConnection(_config.GetConnectionString(_environment));
               connection.Open();   
            //var Data = connection.Query<News,Priorities>(storedProcedure,null,CommandType:CommandType.StoredProcedure);
            //var Data = await connection.QueryAsync<News, Priorities, News>(storedProcedure, (news, priority) => { news.Priority = priority; return news; },parameters,null,false,splitOn: "_priority_id",null, CommandType.StoredProcedure);
            var Data = await connection.QueryAsync<News, Priorities, News>(storedProcedure, (news, priority) => { news.Priority = priority; return news; },parameters,transaction:null,true, splitOn: "_priority_id",null, CommandType.StoredProcedure);
            connection.Close(); 
            return Data;


        }
    }
}
