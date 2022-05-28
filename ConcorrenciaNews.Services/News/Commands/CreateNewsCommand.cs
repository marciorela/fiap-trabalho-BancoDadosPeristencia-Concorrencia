using ConcorrenciaNews.Contracts.Repositories;
using ConcorrenciaNews.Domain.Entities;
using ConcorrenciaNews.Domain.Enumerators;
using ConcorrenciaNews.Services.Notifications;
using MediatR;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Services.Commands
{
    public class CreateNewsCommand : IRequest<Guid>
    {

        public DateTime Data { get; set; } = DateTime.Now;
        public string Titulo { get; set; } = "";
        public string Corpo { get; set; } = "";

        public class CreateNewsCommandHandler: CommandQueryHandlerBase, IRequestHandler<CreateNewsCommand, Guid>
        {
            private readonly INewsRepository _newsRepository;

            public CreateNewsCommandHandler(INewsRepository newsRepository, IMediator mediator, IConnectionMultiplexer db) : base(mediator, db)
            {
                _newsRepository = newsRepository;
            }

            public async Task<Guid> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
            {
                var news = new News()
                {
                    Data = request.Data,
                    Titulo = request.Titulo,
                    Corpo = request.Corpo,
                };

                await _newsRepository.Add(news);

                await _mediator.Publish(new NewsActionNotification { Id = news.Id, Action = ActionNotification.Created}, cancellationToken);

                return news.Id;
            }
        }

    }
}
