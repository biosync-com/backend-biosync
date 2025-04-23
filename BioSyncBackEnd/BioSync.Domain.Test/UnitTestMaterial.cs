using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;

namespace BioSync.Domain.Tests
{
    public class MaterialTests
    {
        #region Testes Positivos de Material

        [Fact(DisplayName = "Criar Material com nome e categoria válidos")]
        public void CriarMaterial_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Material("Papelão", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos de Material

        [Fact(DisplayName = "Criar Material com nome nulo")]
        public void CriarMaterial_ComNomeNulo_DeveLancarExcecao()
        {
            Action action = () => new Material(null, 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome do material é obrigatório");
        }

        [Fact(DisplayName = "Criar Material com nome vazio")]
        public void CriarMaterial_ComNomeVazio_DeveLancarExcecao()
        {
            Action action = () => new Material("", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome do material é obrigatório");
        }

        [Fact(DisplayName = "Criar Material com nome muito curto")]
        public void CriarMaterial_ComNomeMuitoCurto_DeveLancarExcecao()
        {
            Action action = () => new Material("Pl", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome muito curto, mínimo 3 caracteres");
        }

        [Fact(DisplayName = "Criar Material com categoria inválida (0)")]
        public void CriarMaterial_ComCategoriaInvalida_DeveLancarExcecao()
        {
            Action action = () => new Material("Plástico", 0);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Categoria do material inválida");
        }

        #endregion
    }
}

