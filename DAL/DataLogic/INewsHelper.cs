﻿using DAL.Models;

namespace DAL.DataLogic
{
    public interface INewsHelper
    {
        Task DeleteNews(int Id);
        Task<News?> FindNews(int Id);
        Task<IEnumerable<News>> GetNews();
        Task InsertNews(News news);
        Task UpdateNews(News news);
    }
}
