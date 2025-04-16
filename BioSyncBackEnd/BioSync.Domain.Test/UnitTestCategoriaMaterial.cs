using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace BioSync.Domain.Tests
{
    public class CategoriaMaterialTests
    {
        #region Testes Positivos de CategoriaMaterial

        [Fact(DisplayName = "Criar CategoriaMaterial com dados válidos")]
        public void CriarCategoriaMaterial_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new CategoriaMaterial("Recicláveis", "Materiais recicláveis como papel, plástico e vidro");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos de CategoriaMaterial

        [Fact(DisplayName = "Criar CategoriaMaterial com nome nulo")]
        public void CriarCategoriaMaterial_ComNomeNulo_DeveLancarExcecao()
        {
            Action action = () => new CategoriaMaterial(null, "Descrição válida");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome da categoria é obrigatório");
        }

        [Fact(DisplayName = "Criar CategoriaMaterial com nome vazio")]
        public void CriarCategoriaMaterial_ComNomeVazio_DeveLancarExcecao()
        {
            Action action = () => new CategoriaMaterial("", "Descrição válida");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome da categoria é obrigatório");
        }

        [Fact(DisplayName = "Criar CategoriaMaterial com nome muito curto")]
        public void CriarCategoriaMaterial_ComNomeMuitoCurto_DeveLancarExcecao()
        {
            Action action = () => new CategoriaMaterial("AB", "Descrição válida");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome muito curto, mínimo 3 caracteres");
        }

        [Fact(DisplayName = "Criar CategoriaMaterial com descrição nula")]
        public void CriarCategoriaMaterial_ComDescricaoNula_DeveLancarExcecao()
        {
            Action action = () => new CategoriaMaterial("Recicláveis", null);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Descrição é obrigatória");
        }

        [Fact(DisplayName = "Criar CategoriaMaterial com descrição vazia")]
        public void CriarCategoriaMaterial_ComDescricaoVazia_DeveLancarExcecao()
        {
            Action action = () => new CategoriaMaterial("Recicláveis", "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Descrição é obrigatória");
        }

        [Fact(DisplayName = "Criar CategoriaMaterial com descrição muito curta")]
        public void CriarCategoriaMaterial_ComDescricaoMuitoCurta_DeveLancarExcecao()
        {
            Action action = () => new CategoriaMaterial("Recicláveis", "curta");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Descrição muito curta, mínimo 10 caracteres");
        }

        #endregion
    }
}
