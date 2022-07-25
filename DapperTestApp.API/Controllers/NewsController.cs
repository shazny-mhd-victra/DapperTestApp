using DAL.DataLogic;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsHelper _news;

        public NewsController(INewsHelper news)
        {
            _news = news;
        }
        // GET: api/<NewsController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                var data = await _news.GetNews();
               return Results.Ok(data);
            }
            catch (Exception er)
            {
                return Results.Problem(er.Message);
            }
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                var data = await _news.FindNews(id);
                return Results.Ok(data);
            }
            catch (Exception er)
            {
                return Results.Problem(er.Message);
            }
        }

        // POST api/<NewsController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] News news)
        {
            try
            {
                await _news.InsertNews(news);
                return Results.Ok(news);
            }
            catch (Exception er)
            {
                return Results.Problem(er.Message);
            }
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] News news)
        {
            try
            {
                await _news.UpdateNews(news);
                return Results.Ok(news);
            }
            catch (Exception er)
            {
                return Results.Problem(er.Message);
            }
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                await _news.DeleteNews(id);
                return Results.Ok();
            }
            catch (Exception er)
            {
                return Results.Problem(er.Message);
            }
        }
    }
}
