using MediatR;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Services
{
    public class CommandQueryHandlerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IDatabase _db;

        public CommandQueryHandlerBase(IMediator mediator, IConnectionMultiplexer db)
        {
            _mediator = mediator;
            _db = db.GetDatabase();
        }
    }
}
