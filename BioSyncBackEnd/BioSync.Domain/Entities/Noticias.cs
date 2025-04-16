using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Noticias : Entity
    {
        public string Titulo { get; private set; }
        public string Conteudo { get; private set; }
        public string ImagemUrl { get; private set; }
        public DateTime DataPublicacao { get; private set; }
        public string Autor { get; private set; } 

        public Noticias(string titulo, string conteudo, string imagemUrl, string autor)
        {
            ValidateDomain(titulo, conteudo, imagemUrl, autor);
            DataPublicacao = DateTime.Now;
        }

        private void ValidateDomain(string titulo, string conteudo, string imagemUrl, string autor)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(titulo), "Título é obrigatório");
            DomainExceptionValidation.When(titulo.Length < 5, "Título muito curto, mínimo 5 caracteres");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(conteudo), "Conteúdo é obrigatório");
            DomainExceptionValidation.When(conteudo.Length < 20, "Conteúdo muito curto, mínimo 20 caracteres");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(imagemUrl), "URL da imagem é obrigatória");
            DomainExceptionValidation.When(imagemUrl.Length > 250, "URL da imagem muito longa");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(autor), "Autor é obrigatório");

            Titulo = titulo;
            Conteudo = conteudo;
            ImagemUrl = imagemUrl;
            Autor = autor;
        }
    }
}
