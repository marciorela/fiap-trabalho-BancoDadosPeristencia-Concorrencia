using ConcorrenciaNews.Domain;
using ConcorrenciaNews.Domain.Entities;
using ConcorrenciaNews.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Contracts.Repositories
{
    public interface INewsRepository
    {
        IEnumerable<NewsSummary> GetSummary();

        Task<News> GetNewsById(Guid id);

        Task Add(News news);
    }
}
