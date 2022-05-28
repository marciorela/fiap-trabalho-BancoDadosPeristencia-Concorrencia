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
        public Task Handle(ErrorNotitification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine(notification.Error);
            }, cancellationToken);
        }

        public Task Handle(NewsActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"{notification.Id} foi cadastrado.");
            }, cancellationToken);
        }
    }
}
