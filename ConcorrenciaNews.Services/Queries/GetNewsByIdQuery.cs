using ConcorrenciaNews.Contracts.Repositories;
using ConcorrenciaNews.Domain.Entities;
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
    public class GetNewsByIdQuery : IRequest<News>
    {

        public Guid Id { get; set; }

        public class GetNewsByIdQueryHander : CommandQueryHandlerBase, IRequestHandler<GetNewsByIdQuery, News>
        {
            private readonly INewsRepository _newsRepository;

            public GetNewsByIdQueryHander(INewsRepository newsRepository, IMediator mediator, IConnectionMultiplexer db) : base(mediator, db)
            {
                _newsRepository = newsRepository;
            }

            public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
            {
                var result = _db.GetData<News>(request.Id.ToString());
                if (result == null)
                {
                    result = await _newsRepository.GetNewsById(request.Id);
                }

                return result;
            }
        }

    }
}
