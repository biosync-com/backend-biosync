﻿using BioSync.Domain.Entities;
using BioSync.Domain.Enums;
using BioSync.Domain.Validation;
using FluentAssertions;

namespace BioSync.Domain.Tests
{
    public class ColetorTests
    {
        private Endereco EnderecoValido() =>
            new Endereco("Av. Brasil", "456", "Centro", "Cidade", Estado.MG, "99999-999");

        private Coletor CriarColetorValido() =>
            new Coletor(
                "João",
                "12345678901",
                "11999999999",
                "joao@email.com",
                EnderecoValido(),
                "documento.jpg",
                "senha12345");

        #region Testes Positivos

        [Fact(DisplayName = "Criar Coletor com dados válidos")]
        public void CriarColetor_ComParametrosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => CriarColetorValido();
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Coletor deve iniciar com listas vazias")]
        public void Coletor_DeveIniciarComListasVazias()
        {
            var coletor = CriarColetorValido();

            coletor.AgendamentosAceitos.Should().BeEmpty();
            //coletor.MateriaisColetados.Should().BeEmpty();
        }

        [Fact(DisplayName = "Coletor deve conseguir aceitar agendamento")]
        public void AceitarAgendamento_Valido_DeveAdicionarNaLista()
        {
            var coletor = CriarColetorValido();
            var agendamento = new Agendamento(
                DateTime.Now.AddDays(1),
                TimeSpan.FromHours(8),
                TimeSpan.FromHours(10),
                5,
                "foto.jpg",
                "obs");

            coletor.AceitarAgendamento(agendamento);

            coletor.AgendamentosAceitos.Should().ContainSingle().Which.Should().Be(agendamento);
        }

        //[Fact(DisplayName = "Coletor deve conseguir adicionar material à lista")]
        //public void AdicionarMaterial_Valido_DeveAdicionarComSucesso()
        //{
            //var coletor = CriarColetorValido();
            //var material = new Material("Papelão", 1);

            //coletor.AdicionarMaterial(material);

            //coletor.MateriaisColetados.Should().ContainSingle().Which.Should().Be(material);
        //}

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Coletor com senha muito curta deve lançar exceção")]
        public void CriarColetor_ComSenhaCurta_DeveLancarExcecao()
        {
            Action action = () => new Coletor(
                "João",
                "12345678901",
                "11999999999",
                "joao@email.com",
                EnderecoValido(),
                "documento.jpg",
                "123");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Senha muito curta, mínimo 8 caracteres");
        }

        [Fact(DisplayName = "Coletor não deve aceitar agendamento nulo")]
        public void AceitarAgendamento_Nulo_DeveLancarExcecao()
        {
            var coletor = CriarColetorValido();

            Action action = () => coletor.AceitarAgendamento(null!);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Agendamento inválido.");
        }

        //[Fact(DisplayName = "Coletor não deve adicionar material nulo")]
        //public void AdicionarMaterial_Nulo_DeveLancarExcecao()
        //{
            //var coletor = CriarColetorValido();

            //Action action = () => coletor.AdicionarMaterial(null!);

            //action.Should().Throw<DomainExceptionValidation>()
                //.WithMessage("Material inválido.");
        //}

        #endregion
    }
}
