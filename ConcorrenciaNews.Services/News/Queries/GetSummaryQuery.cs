using ConcorrenciaNews.Contracts.Repositories;
using ConcorrenciaNews.Domain.Model;
using ConcorrenciaNews.Helpers;
using MediatR;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Services.Queries
{
    public class GetSummaryQuery : IRequest<IEnumerable<NewsSummary>>
    {

        public class GetSummaryQueryHander : CommandQueryHandlerBase, IRequestHandler<GetSummaryQuery, IEnumerable<NewsSummary>>
        {
            private readonly INewsRepository _newsRepository;

            public GetSummaryQueryHander(INewsRepository newsRepository, IMediator mediator, IConnectionMultiplexer db) : base(mediator, db)
            {
                _newsRepository = newsRepository;
            }

            public async Task<IEnumerable<NewsSummary>> Handle(GetSummaryQuery request, CancellationToken cancellationToken)
            {
                var list = _db.GetData<IEnumerable<NewsSummary>>("summary");
                if (list == null)
                {
                    list = await _newsRepository.GetSummary();

                    if (list.Any())
                    {
                        _db.SetData("summary", list, TimeSpan.FromSeconds(60));
                    }
                }

                return list;
            }
        }

    }
}
