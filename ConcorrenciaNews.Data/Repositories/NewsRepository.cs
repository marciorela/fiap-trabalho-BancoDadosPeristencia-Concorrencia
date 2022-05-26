using ConcorrenciaNews.AppDbContext;
using ConcorrenciaNews.Contracts.Repositories;
using ConcorrenciaNews.Domain.Entities;
using ConcorrenciaNews.Domain.Model;
using ConcorrenciaNews.Helpers;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Data.Repositories
{
    public class NewsRepository : RepositoryBase, INewsRepository
    {
        private readonly IDatabase _db;

        public NewsRepository(MainDbContext ctx, IConnectionMultiplexer db) : base(ctx)
        {
            _db = db.GetDatabase();
        }

        public async Task Add(News news)
        {
            await _ctx.News.AddAsync(news);
            await _ctx.SaveChangesAsync();
        }

        public async Task<News> GetNewsById(Guid id)
        {
            var result = _db.GetData<News>(id.ToString());
            if (result == null)
            {
                result = await _ctx.News.FirstOrDefaultAsync(x => x.Id == id);
                if (result != null)
                {
                    _db.SetData(id.ToString(), result, TimeSpan.FromMinutes(5));
                }
            }

            return result;
        }

        public IEnumerable<NewsSummary> GetSummary()
        {

            var list = _db.GetData<List<NewsSummary>>("summary");
            if (list == null)
            {
                list = _ctx.News
                    .Select(n => new NewsSummary { Id = n.Id, Data = n.Data, Titulo = n.Titulo })
                    .OrderByDescending(o => o.Data)
                    .Take(20)
                    .ToList();

                if (list.Any())
                {
                    _db.SetData("summary", list, TimeSpan.FromSeconds(60));
                }
            }

            return list;
        }
    }
}
