using ConcorrenciaNews.Domain.Entities;
using ConcorrenciaNews.Domain.Model;
using ConcorrenciaNews.Domain.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Contracts.Repositories
{
    public interface IQueryRepository
    {
        Task AddNewsAsync(News news);

        Task<News> GetByIdAsync(Guid id);

        Task<IEnumerable<NewsSummary>> GetSummaryAsync();
    }
}
