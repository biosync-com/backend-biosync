using BioSync.Domain.Enums;
using BioSync.Domain.Validation;
using FluentAssertions;

namespace BioSync.Domain.Entities.Tests
{
    public class PontoDescarteTests
    {
        private Endereco EnderecoValido() =>
             new Endereco("Rua das Árvores", "321", "Centro", "Cidade Verde", Estado.SP, "12345-678");

        #region Testes Positivos

        [Fact(DisplayName = "Criar Ponto com CPF válido")]
        public void CriarPontoDescarte_ComCpfValido_NaoDeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "EcoPonto Bairro A",
                cpf: "12345678901",
                cnpj: null,
                telefone: "11999999999",
                emailOuSite: "contato@ecoponto.com",
                nomeResponsavel: "Maria Silva",
                endereco: EnderecoValido());

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Ponto com CNPJ válido")]
        public void CriarPontoDescarte_ComCnpjValido_NaoDeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "EcoPonto Bairro B",
                cpf: null,
                cnpj: "12345678000199",
                telefone: "11988888888",
                emailOuSite: "site.com",
                nomeResponsavel: "João Souza",
                endereco: EnderecoValido());

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Ponto sem CPF e CNPJ deve lançar exceção")]
        public void CriarPontoDescarte_SemCpfECnpj_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "EcoPonto",
                cpf: "",
                cnpj: "",
                telefone: "11999999999",
                emailOuSite: "contato@ecoponto.com",
                nomeResponsavel: "João",
                endereco: EnderecoValido());

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("É necessário fornecer CPF ou CNPJ");
        }

        [Fact(DisplayName = "Criar Ponto com CPF inválido deve lançar exceção")]
        public void CriarPontoDescarte_ComCpfInvalido_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "EcoPonto",
                cpf: "123",
                cnpj: null,
                telefone: "11999999999",
                emailOuSite: "contato@ecoponto.com",
                nomeResponsavel: "João",
                endereco: EnderecoValido());

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("CPF inválido");
        }

        [Fact(DisplayName = "Criar Ponto com CNPJ inválido deve lançar exceção")]
        public void CriarPontoDescarte_ComCnpjInvalido_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "EcoPonto",
                cpf: null,
                cnpj: "1234",
                telefone: "11999999999",
                emailOuSite: "site.com",
                nomeResponsavel: "João",
                endereco: EnderecoValido());

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("CNPJ inválido");
        }

        [Fact(DisplayName = "Criar Ponto com nome curto deve lançar exceção")]
        public void CriarPontoDescarte_ComNomeCurto_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "AB",
                cpf: "12345678901",
                cnpj: null,
                telefone: "11999999999",
                emailOuSite: "email@ecoponto.com",
                nomeResponsavel: "Maria",
                endereco: EnderecoValido());

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome muito curto, mínimo 3 caracteres");
        }

        [Fact(DisplayName = "Criar Ponto com telefone inválido deve lançar exceção")]
        public void CriarPontoDescarte_ComTelefoneInvalido_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "EcoPonto",
                cpf: "12345678901",
                cnpj: null,
                telefone: "123",
                emailOuSite: "email@ecoponto.com",
                nomeResponsavel: "Maria",
                endereco: EnderecoValido());

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Telefone inválido");
        }

        [Fact(DisplayName = "Criar Ponto sem contato deve lançar exceção")]
        public void CriarPontoDescarte_SemEmailOuSite_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "EcoPonto",
                cpf: "12345678901",
                cnpj: null,
                telefone: "11999999999",
                emailOuSite: "",
                nomeResponsavel: "Maria",
                endereco: EnderecoValido());

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Contato por e-mail ou site é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto sem nome do responsável deve lançar exceção")]
        public void CriarPontoDescarte_SemResponsavel_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "EcoPonto",
                cpf: "12345678901",
                cnpj: null,
                telefone: "11999999999",
                emailOuSite: "email@ecoponto.com",
                nomeResponsavel: "",
                endereco: EnderecoValido());

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome do responsável é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto sem endereço deve lançar exceção")]
        public void CriarPontoDescarte_SemEndereco_DeveLancarExcecao()
        {
            Action action = () => new PontoDescarte(
                nome: "EcoPonto",
                cpf: "12345678901",
                cnpj: null,
                telefone: "11999999999",
                emailOuSite: "email@ecoponto.com",
                nomeResponsavel: "Maria",
                endereco: null!);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Endereço é obrigatório");
        }

        #endregion
    }
}

