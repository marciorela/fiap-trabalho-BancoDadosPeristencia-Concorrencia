using ConcorrenciaNews.Contracts.Repositories;
using ConcorrenciaNews.Domain.Entities;
using ConcorrenciaNews.Domain.Model;
using ConcorrenciaNews.Domain.Query;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Data.Repositories
{
    public class QueryRepository: IQueryRepository
    {
        const string NewsCollection = "news";

        private readonly IMongoDatabase _db;

        public QueryRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoConnection"));
            _db = client.GetDatabase("newsRead");
        }

        public async Task AddNewsAsync(News news)
        {
            var col = _db.GetCollection<News>(NewsCollection);
            await col.InsertOneAsync(news);
        }

        public async Task<News> GetByIdAsync(Guid id)
        {
            var col = _db.GetCollection<News>(NewsCollection);
            return await col.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NewsSummary>> GetSummaryAsync()
        {
            var col = _db.GetCollection<News>(NewsCollection);
            return await Task.Run(() => col.AsQueryable()
                .Select(n => new NewsSummary { Id = n.Id, Data = n.Data, Titulo = n.Titulo })
                .OrderByDescending(o => o.Data)
                .Take(20)
                .ToList()
                );
        }
    }
    }
