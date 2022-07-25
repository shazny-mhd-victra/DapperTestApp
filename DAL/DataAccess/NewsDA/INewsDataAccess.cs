using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess.NewsDA
{
    public interface INewsDataAccess : IDataAccess<News>
    {
        Task<IEnumerable<News>> GetData<T,U>(string storedProcedure,U parameters);
    }
}
