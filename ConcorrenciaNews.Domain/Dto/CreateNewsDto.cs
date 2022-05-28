using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcorrenciaNews.Domain.Dto
{
    public class CreateNewsDto
    {

        [Required(ErrorMessage = "Título deve ser informado.")]
        [StringLength(200)]
        public string Titulo { get; set; } = "";

        [Required(ErrorMessage = "Corpo da notícia deve ser informado.")]
        public string Corpo { get; set; } = "";
    }
}
