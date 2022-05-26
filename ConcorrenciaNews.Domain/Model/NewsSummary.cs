using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Domain.Model
{
    public class NewsSummary
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public string Titulo { get; set; } = "";

        public NewsSummary()
        {
            Id = Guid.NewGuid();
        }

    }
}
