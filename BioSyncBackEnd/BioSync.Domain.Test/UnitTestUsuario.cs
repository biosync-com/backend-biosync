using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace BioSync.Domain.Entities.Tests
{
    public class UsuarioTests
    {
        #region Testes Positivos de Usuario
        [Fact(DisplayName = "Criar Usuário Com Estado Válido")]
        public void CriarUsuario_ComParametrosValidos_ResultObjetoEstadoValido()
        {
            Endereco endereco = new Endereco("Rua Agasaki", "777", "Tori Tori", "Kizuna Silver", "Kizuna Five", "25962115");
            Pessoa pessoa = new Pessoa("Goury Gabriev", "32599874255", "16962574986", "goury.lightofsword@slayers.com", endereco, "gglos.jpg");

            Action action = () => new Usuario(pessoa, endereco);

            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Usuario

        [Fact(DisplayName = "Criar Usuário Com Pessoa Nula")]
        public void CriarUsuario_ComPessoaNula_ResultArgumentNullException()
        {
            Endereco endereco = new Endereco("Rua Agasaki", "777", "Tori Tori", "Kizuna Silver", "Kizuna Five", "25962115");

            Action action = () => new Usuario(null, endereco);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "Criar Usuário Com Endereco Nulo")]
        public void CriarUsuario_ComEnderecoNulo_ResultArgumentNullException()
        {
            Pessoa pessoa = new Pessoa("Goury Gabriev", "32599874255", "16962574986", "goury.lightofsword@slayers.com", new Endereco("Rua Agasaki", "777", "Tori Tori", "Kizuna Silver", "Kizuna Five", "25962115"), "gglos.jpg");

            Action action = () => new Usuario(pessoa, null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "Criar Usuário Com CPF Inválido")]
        public void CriarUsuario_ComCpfInvalido_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Agasaki", "777", "Tori Tori", "Kizuna Silver", "Kizuna Five", "25962115");
            Action action = () => new Usuario(new Pessoa("Goury Gabriev", "12345", "16962574986", "goury.lightofsword@slayers.com", endereco, "gglos.jpg"), endereco);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("CPF inválido");
        }

        [Fact(DisplayName = "Criar Usuário Com Email Inválido")]
        public void CriarUsuario_ComEmailInvalido_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Agasaki", "777", "Tori Tori", "Kizuna Silver", "Kizuna Five", "25962115");
            Action action = () => new Usuario(new Pessoa("Goury Gabriev", "32599874255", "16962574986", "emailinvalido", endereco, "gglos.jpg"), endereco);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Email inválido");
        }
        #endregion
    }
}
