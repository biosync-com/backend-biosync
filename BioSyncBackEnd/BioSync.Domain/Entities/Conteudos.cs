using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Conteudos : Entity
    {
        public string Titulo { get; private set; }
        public string Texto { get; private set; }
        public string ImagemUrl { get; private set; }
        public string? VideoUrl { get; private set; } 
        public DateTime DataPublicacao { get; private set; }

        public Conteudos(string titulo, string texto, string imagemUrl, string? videoUrl = null)
        {
            ValidateDomain(titulo, texto, imagemUrl, videoUrl);
            DataPublicacao = DateTime.Now;
        }

        private void ValidateDomain(string titulo, string texto, string imagemUrl, string? videoUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(titulo), "Título é obrigatório");
            DomainExceptionValidation.When(titulo.Length < 5, "Título muito curto, mínimo 5 caracteres");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(texto), "Texto é obrigatório");
            DomainExceptionValidation.When(texto.Length < 20, "Texto muito curto, mínimo 20 caracteres");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(imagemUrl), "URL da imagem é obrigatória");
            DomainExceptionValidation.When(imagemUrl.Length > 250, "URL da imagem muito longa");

            if (!string.IsNullOrWhiteSpace(videoUrl))
            {
                DomainExceptionValidation.When(videoUrl.Length > 250, "URL do vídeo muito longa");
            }

            Titulo = titulo;
            Texto = texto;
            ImagemUrl = imagemUrl;
            VideoUrl = videoUrl;
        }
    }
}
