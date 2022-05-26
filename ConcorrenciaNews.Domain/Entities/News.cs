using System.ComponentModel.DataAnnotations;

namespace ConcorrenciaNews.Domain.Entities
{
    public class News
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Título deve ser informado.")]
        [StringLength(200)]
        public string Titulo { get; set; } = "";

        [Required(ErrorMessage = "Corpo da notícia deve ser informado.")]
        public string Corpo { get; set; } = "";

        public News()
        {
            Id = Guid.NewGuid();
        }

    }
}
