using BioSync.Domain.Entities;
using BioSync.Domain.Enums;
using BioSync.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace BioSync.Domain.Tests
{
    public class UsuarioTests
    {
        private Endereco EnderecoValido() =>
            new Endereco("Rua X", "123", "Bairro", "Cidade", Estado.SP, "12345-678");

        #region Testes Positivos

        [Fact(DisplayName = "Criar Usuario com dados válidos")]
        public void CriarUsuario_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Usuario(
                nome: "Maria",
                cpf: "12345678901",
                telefone: "11999999999",
                email: "maria@email.com",
                endereco: EnderecoValido(),
                fotoDocumento: "foto.jpg",
                senha: "senha1234",
                tipo: TipoUsuario.Comum);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Usuario deve definir email como não verificado")]
        public void CriarUsuario_EmailVerificado_DeveSerFalso()
        {
            var usuario = new Usuario(
                "Carlos",
                "12345678901",
                "11988888888",
                "carlos@email.com",
                EnderecoValido(),
                "foto.jpg",
                "senha12345",
                TipoUsuario.Comum);

            usuario.EmailVerificado.Should().BeFalse();
        }

        [Fact(DisplayName = "Verificar email deve mudar status")]
        public void VerificarEmail_DeveAlterarEmailVerificadoParaTrue()
        {
            var usuario = new Usuario(
                "Fernanda",
                "12345678901",
                "11911112222",
                "fernanda@email.com",
                EnderecoValido(),
                "foto.jpg",
                "senha12345",
                TipoUsuario.Comum);

            usuario.VerificarEmail();
            usuario.EmailVerificado.Should().BeTrue();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Usuario com nome nulo deve lançar exceção")]
        public void CriarUsuario_ComNomeNulo_DeveLancarExcecao()
        {
            Action action = () => new Usuario(
                nome: null,
                cpf: "12345678901",
                telefone: "11999999999",
                email: "email@email.com",
                endereco: EnderecoValido(),
                fotoDocumento: "foto.jpg",
                senha: "senha1234",
                tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome é obrigatório");
        }

        [Fact(DisplayName = "Criar Usuario com senha muito curta deve lançar exceção")]
        public void CriarUsuario_ComSenhaCurta_DeveLancarExcecao()
        {
            Action action = () => new Usuario(
                nome: "João",
                cpf: "12345678901",
                telefone: "11999999999",
                email: "joao@email.com",
                endereco: EnderecoValido(),
                fotoDocumento: "foto.jpg",
                senha: "123",
                tipo: TipoUsuario.Comum);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Senha inválida, mínimo 8 caracteres.");
        }

        #endregion
    }
}
