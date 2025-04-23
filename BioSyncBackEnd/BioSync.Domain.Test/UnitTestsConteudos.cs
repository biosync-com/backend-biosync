using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;

namespace BioSync.Domain.Test
{
    public class UnitTestsConteudos
    {

        #region Testes Positivos

        [Fact(DisplayName = "Criar Conteúdo com dados válidos e vídeo opcional")]
        public void CriarConteudo_ComDadosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Conteudos(
                "Título do conteúdo",
                "Texto completo com mais de vinte caracteres.",
                "https://site.com/imagem.jpg");

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Conteúdo com vídeo válido")]
        public void CriarConteudo_ComVideoValido_NaoDeveLancarExcecao()
        {
            Action action = () => new Conteudos(
                "Título válido",
                "Texto com no mínimo vinte caracteres.",
                "https://site.com/imagem.jpg",
                "https://site.com/video.mp4");

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Conteúdo com título muito curto")]
        public void CriarConteudo_TituloCurto_DeveLancarExcecao()
        {
            Action action = () => new Conteudos(
                "ABC",
                "Texto com mais de vinte caracteres.",
                "https://site.com/imagem.jpg");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Título muito curto, mínimo 5 caracteres");
        }

        [Fact(DisplayName = "Criar Conteúdo com texto muito curto")]
        public void CriarConteudo_TextoCurto_DeveLancarExcecao()
        {
            Action action = () => new Conteudos(
                "Título válido",
                "Texto curto",
                "https://site.com/imagem.jpg");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Texto muito curto, mínimo 20 caracteres");
        }

        [Fact(DisplayName = "Criar Conteúdo com imagem vazia")]
        public void CriarConteudo_SemImagem_DeveLancarExcecao()
        {
            Action action = () => new Conteudos(
                "Título válido",
                "Texto válido com mais de vinte caracteres.",
                "");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("URL da imagem é obrigatória");
        }

        [Fact(DisplayName = "Criar Conteúdo com URL da imagem muito longa")]
        public void CriarConteudo_ImagemMuitoLonga_DeveLancarExcecao()
        {
            string urlLonga = new string('a', 251);

            Action action = () => new Conteudos(
                "Título válido",
                "Texto válido com mais de vinte caracteres.",
                urlLonga);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("URL da imagem muito longa");
        }

        [Fact(DisplayName = "Criar Conteúdo com vídeo muito longo")]
        public void CriarConteudo_VideoMuitoLongo_DeveLancarExcecao()
        {
            string videoUrl = new string('x', 251);

            Action action = () => new Conteudos(
                "Título válido",
                "Texto com pelo menos vinte caracteres.",
                "https://site.com/imagem.jpg",
                videoUrl);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("URL do vídeo muito longa");
        }

        #endregion

    }
}
