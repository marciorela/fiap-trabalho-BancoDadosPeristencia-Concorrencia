using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Domain.Query
{
    public class SummaryQuery
    {
        public Guid? Id { get; set; }

        public DateTime? Data { get; set; } = DateTime.Now;

        public string? Titulo { get; set; } = "";
    }
}
