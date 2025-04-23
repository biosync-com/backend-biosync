using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class ConteudosDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [MinLength(5, ErrorMessage = "O título deve ter no mínimo 5 caracteres")]
        [MaxLength(250, ErrorMessage = "O título não pode ter mais de 250 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O texto é obrigatório")]
        [MinLength(20, ErrorMessage = "O texto deve ter no mínimo 20 caracteres")]
        public string Texto { get; set; }

        [Required(ErrorMessage = "A URL da imagem é obrigatória")]
        [MaxLength(250, ErrorMessage = "A URL da imagem não pode ter mais de 250 caracteres")]
        public string ImagemUrl { get; set; }

        [MaxLength(250, ErrorMessage = "A URL do vídeo não pode ter mais de 250 caracteres")]
        public string? VideoUrl { get; set; }

        [Required(ErrorMessage = "A data de publicação é obrigatória")]
        public DateTime DataPublicacao { get; set; }

        public ConteudosDTO(int id, string titulo, string texto, string imagemUrl, string? videoUrl, DateTime dataPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Texto = texto;
            ImagemUrl = imagemUrl;
            VideoUrl = videoUrl;
            DataPublicacao = dataPublicacao;
        }
    }
}
