using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Domain.Query
{
    public class NewsQuery
    {
        public Guid? Id { get; set; }

        public DateTime? Data { get; set; } = DateTime.Now;

        public string? Titulo { get; set; } = "";

        public string? Corpo { get; set; } = "";

    }
}
