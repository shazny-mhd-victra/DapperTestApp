using DAL.DataAccess.NewsDA;
using DAL.Models;

namespace DAL.DataLogic
{
    public class NewsHelper : INewsHelper
    {
        private readonly INewsDataAccess _db;

        public NewsHelper(INewsDataAccess db)
        {
           _db = db;
        }

        public Task DeleteNews(int Id)
        => _db.SaveData(storedProcedure: "dbo.spNewsDelete", new { Id = Id });


        public async Task<News?> FindNews(int Id)
        {
            var results = await _db.GetData<News,dynamic>(storedProcedure: "dbo.spNewsGet", new { Id =Id });
            return results.FirstOrDefault();
        }

       public async Task<IEnumerable<News>> GetNews()
        {
           var data = await _db.GetData<News, dynamic>("dbo.spNewsGetAll", new {});
            return data;
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
                => _db.SaveData(storedProcedure: "dbo.spNewsUpdate", new
                {
                    news._news_id,
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


    }
}
