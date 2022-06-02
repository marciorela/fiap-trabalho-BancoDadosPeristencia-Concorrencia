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

        public class GetNewsByIdQueryHander : CommandQueryHandlerBase, IRequestHandler<GetNewsByIdQuery, News?>
        {
            private readonly IQueryRepository _queryRepository;

            public GetNewsByIdQueryHander(IQueryRepository queryRepository, IMediator mediator, IConnectionMultiplexer db) : base(mediator, db)
            {
                _queryRepository = queryRepository;
            }

            public async Task<News?> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
            {
                var result = _db.GetData<News>(request.Id.ToString());
                if (result == null)
                {
                    result = await _queryRepository.GetByIdAsync(request.Id);

                    if (result != null)
                    {
                        _db.SetData(request.Id.ToString(), result, TimeSpan.FromSeconds(60));
                    }
                }

                return result;
            }
        }

    }
}
