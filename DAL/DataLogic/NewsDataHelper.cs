using DAL.DataAccess;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataLogic
{
    public class NewsDataHelper : INewsDataHelper
    {
        private readonly INewsDataAccess _db;

        public NewsDataHelper(INewsDataAccess db)
        {
            _db = db;
        }

        //public Task<IEnumerable<News>> GetNews()
        //    => _db.LoadData<News, dynamic>(storedProcedure: "dbo.spNewsGetAll", new { });
        public Task<IEnumerable<News>> GetNews()
            => _db.LoadData<News,dynamic>(storedProcedure: "dbo.spNewsGetAll", new { });
        public async Task<News?> FindNews(int Id)
        {
            var results = await _db.LoadData<News, dynamic>(storedProcedure: "dbo.spNewsGet", new { });
            return results.FirstOrDefault();
        }
        public Task InsertNews(News news)
        => _db.SaveData(storedProcedure: "dbo.spNewsInsert", new
        {
            news._priority_id, 
            news._title,
            news._description,
            news._start_date,
            news._end_date,
            news._primary_image,
            news._secondary_image,
            news._is_deleted,
            news._video_url,
            news._short_description
        });
        public Task UpdateNews(News news)
        => _db.SaveData(storedProcedure: "dbo.spNewsUpdate", news);
        public Task DeleteNews(int Id)
        => _db.SaveData(storedProcedure: "dbo.spNewsDelete", new { Id = Id });
    }
}
