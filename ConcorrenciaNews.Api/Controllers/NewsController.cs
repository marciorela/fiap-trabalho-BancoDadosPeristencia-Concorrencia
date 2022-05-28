using ConcorrenciaNews.Domain;
using ConcorrenciaNews.Domain.Dto;
using ConcorrenciaNews.Domain.Entities;
using ConcorrenciaNews.Domain.Model;
using ConcorrenciaNews.Services.Commands;
using ConcorrenciaNews.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("summary")]
        public async Task<IEnumerable<NewsSummary>> GetSummary()
        {
            var list = await _mediator.Send(new GetSummaryQuery());

            return list;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNews(Guid id)
        {
            var news = await _mediator.Send(new GetNewsByIdQuery() { Id = id });
            if (news == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(news);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateNewsDto news)
        {
            var guidCreated = await _mediator.Send(new CreateNewsCommand()
            {
                Titulo = news.Titulo,
                Corpo = news.Corpo
            });

            return Created(guidCreated.ToString(), news);
        }

    }
}
