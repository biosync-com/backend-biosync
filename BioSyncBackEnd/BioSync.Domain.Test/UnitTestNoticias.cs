using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;

namespace BioSync.Domain.Test
{
    public class UnitTestNoticias
    {
        #region Testes Positivos

        [Fact(DisplayName = "Criar Notícia com dados válidos")]
        public void CriarNoticia_ComDadosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Noticias(
                "Nova Iniciativa Ambiental",
                "O projeto visa conscientizar sobre a reciclagem e práticas sustentáveis.",
                "https://site.com/imagem.jpg",
                "Equipe BioSync");

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Notícia com título muito curto")]
        public void CriarNoticia_TituloCurto_DeveLancarExcecao()
        {
            Action action = () => new Noticias(
                "Hey",
                "Texto válido com mais de vinte caracteres.",
                "https://site.com/imagem.jpg",
                "Autor");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Título muito curto, mínimo 5 caracteres");
        }

        [Fact(DisplayName = "Criar Notícia com conteúdo muito curto")]
        public void CriarNoticia_ConteudoCurto_DeveLancarExcecao()
        {
            Action action = () => new Noticias(
                "Título válido",
                "Muito curto",
                "https://site.com/imagem.jpg",
                "Autor");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Conteúdo muito curto, mínimo 20 caracteres");
        }

        [Fact(DisplayName = "Criar Notícia com imagem vazia")]
        public void CriarNoticia_SemImagem_DeveLancarExcecao()
        {
            Action action = () => new Noticias(
                "Título válido",
                "Texto com mais de vinte caracteres.",
                "",
                "Autor");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("URL da imagem é obrigatória");
        }

        [Fact(DisplayName = "Criar Notícia com imagem muito longa")]
        public void CriarNoticia_ImagemMuitoLonga_DeveLancarExcecao()
        {
            string urlLonga = new string('a', 251);

            Action action = () => new Noticias(
                "Título válido",
                "Texto com mais de vinte caracteres.",
                urlLonga,
                "Autor");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("URL da imagem muito longa");
        }

        [Fact(DisplayName = "Criar Notícia com autor vazio")]
        public void CriarNoticia_SemAutor_DeveLancarExcecao()
        {
            Action action = () => new Noticias(
                "Título válido",
                "Texto com mais de vinte caracteres.",
                "https://site.com/imagem.jpg",
                "");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Autor é obrigatório");
        }

        #endregion
    }
}

