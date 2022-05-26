using ConcorrenciaNews.Data.Repositories;
using ConcorrenciaNews.Domain;
using ConcorrenciaNews.Domain.Entities;
using ConcorrenciaNews.Domain.Model;
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
        private readonly NewsRepository _newsRepository;

        public NewsController(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet("summary")]
        public IEnumerable<NewsSummary> GetSummary()
        {
            var list = _newsRepository.GetSummary();

            return list;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNews(Guid id)
        {
            var news = await _newsRepository.GetNewsById(id);
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
        public async Task<IActionResult> Post(News news)
        {
            await _newsRepository.Add(news);

            return Created(news.Id.ToString(), news);
        }

    }
}
