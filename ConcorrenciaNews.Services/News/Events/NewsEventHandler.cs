using ConcorrenciaNews.Contracts.Repositories;
using ConcorrenciaNews.Domain.Enumerators;
using ConcorrenciaNews.Domain.Query;
using ConcorrenciaNews.Services.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Services.Events
{
    public class NewsEventHandler : INotificationHandler<NewsActionNotification>, INotificationHandler<ErrorNotitification>
    {
        private readonly IQueryRepository _queryRepository;

        public NewsEventHandler(IQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public Task Handle(ErrorNotitification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine(notification.Error);
            }, cancellationToken);
        }

        public async Task Handle(NewsActionNotification notification, CancellationToken cancellationToken)
        {
            if (notification.Action == ActionNotification.Created && notification.news != null)
            {
                await _queryRepository.AddNewsAsync(notification.news);

                Console.WriteLine($"{notification.news?.Id} foi cadastrado.");
            }
        }
    }
}
