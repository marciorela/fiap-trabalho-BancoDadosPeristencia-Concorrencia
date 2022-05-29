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
        public NewsRepository(MainDbContext ctx) : base(ctx)
        {
        }

        public async Task Add(News news)
        {
            await _ctx.News.AddAsync(news);
            await _ctx.SaveChangesAsync();
        }

        //public async Task<News?> GetNewsById(Guid id)
        //{
        //    return await _ctx.News.FirstOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task<IEnumerable<NewsSummary>> GetSummary()
        //{
        //    return await _ctx.News
        //        .Select(n => new NewsSummary { Id = n.Id, Data = n.Data, Titulo = n.Titulo })
        //        .OrderByDescending(o => o.Data)
        //        .Take(20)
        //        .ToListAsync();
        //}
    }
}
