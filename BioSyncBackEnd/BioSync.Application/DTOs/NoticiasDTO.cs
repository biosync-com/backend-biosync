using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class NoticiasDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [MinLength(5, ErrorMessage = "O título deve ter no mínimo 5 caracteres")]
        [MaxLength(150, ErrorMessage = "O título não pode ter mais de 150 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O conteúdo é obrigatório")]
        [MinLength(20, ErrorMessage = "O conteúdo deve ter no mínimo 20 caracteres")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "A URL da imagem é obrigatória")]
        [MaxLength(250, ErrorMessage = "A URL da imagem não pode ter mais de 250 caracteres")]
        public string ImagemUrl { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do autor não pode ter mais de 100 caracteres")]
        public string Autor { get; set; }

        public DateTime DataPublicacao { get; set; }

        public NoticiasDTO(int id, string titulo, string conteudo, string imagemUrl, string autor, DateTime dataPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Conteudo = conteudo;
            ImagemUrl = imagemUrl;
            Autor = autor;
            DataPublicacao = dataPublicacao;
        }
    }
}
