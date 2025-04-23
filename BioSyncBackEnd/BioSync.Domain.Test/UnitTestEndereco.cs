using BioSync.Domain.Entities;
using BioSync.Domain.Enums;
using BioSync.Domain.Validation;
using FluentAssertions;

namespace BioSync.Domain.Tests
{
    public class EnderecoTests
    {
        #region Testes Positivos de Endereco

        [Fact(DisplayName = "Criar Endereco com dados válidos")]
        public void CriarEndereco_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Endereco(
                "Rua Exemplo",
                "123",
                "Centro",
                "São Paulo",
                Estado.SP,
                "12345-678"
            );

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos de Endereco

        [Fact(DisplayName = "Criar Endereco com Rua vazia")]
        public void CriarEndereco_ComRuaVazia_DeveLancarExcecao()
        {
            Action action = () => new Endereco(
                "",
                "123",
                "Centro",
                "Cidade",
                Estado.MG,
                "12345-678"
            );

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Rua é obrigatória");
        }

        [Fact(DisplayName = "Criar Endereco com número vazio")]
        public void CriarEndereco_ComNumeroVazio_DeveLancarExcecao()
        {
            Action action = () => new Endereco(
                "Rua A",
                "",
                "Bairro",
                "Cidade",
                Estado.MG,
                "12345-678"
            );

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Número é obrigatório");
        }

        [Fact(DisplayName = "Criar Endereco com bairro nulo")]
        public void CriarEndereco_ComBairroNulo_DeveLancarExcecao()
        {
            Action action = () => new Endereco(
                "Rua B",
                "456",
                null,
                "Cidade",
                Estado.MG,
                "12345-678"
            );

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Bairro é obrigatório");
        }

        [Fact(DisplayName = "Criar Endereco com cidade vazia")]
        public void CriarEndereco_ComCidadeVazia_DeveLancarExcecao()
        {
            Action action = () => new Endereco(
                "Rua C",
                "789",
                "Bairro",
                "",
                Estado.MG,
                "12345-678"
            );

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Cidade é obrigatória");
        }

        [Fact(DisplayName = "Criar Endereco com CEP vazio")]
        public void CriarEndereco_ComCepVazio_DeveLancarExcecao()
        {
            Action action = () => new Endereco(
                "Rua C",
                "789",
                "Bairro",
                "Cidade",
                Estado.MG,
                ""
            );

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("CEP é obrigatório");
        }

        [Fact(DisplayName = "Criar Endereco com estado inválido")]
        public void CriarEndereco_ComEstadoInvalido_DeveLancarExcecao()
        {
            Action action = () => new Endereco(
                "Rua D",
                "321",
                "Bairro",
                "Cidade",
                (Estado)99,
                "12345-678"
            );

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Estado inválido");
        }

        #endregion
    }
}
