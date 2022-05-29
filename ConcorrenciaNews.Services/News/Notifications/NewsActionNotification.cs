using ConcorrenciaNews.Domain.Entities;
using ConcorrenciaNews.Domain.Enumerators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Services.Notifications
{
    public class NewsActionNotification : INotification
    {
        public News? news { get; set; }
        public ActionNotification Action { get; set; }
    }
}
