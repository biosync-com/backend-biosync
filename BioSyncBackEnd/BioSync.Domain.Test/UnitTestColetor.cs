using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace BioSync.Domain.Entities.Tests
{
    public class ColetorTests
    {
        #region Testes Positivos de Coletor
        [Fact(DisplayName = "Criar Coletor Com Estado Válido")]
        public void CriarColetor_ComParametrosValidos_ResultObjetoEstadoValido()
        {
            Endereco endereco = new Endereco("Rua Vai dar Bom", "627", "Brave In", "Gaburincho", "Kyoryugers", "25962314");
            Pessoa pessoa = new Pessoa("Daigo Omura", "65495135782", "16987421680", "daigo.carnival@zyuden.com", endereco, "foto.jpg");
            Material material = new Material("Material Teste", "kg", 1);

            Action action = () => new Coletor(pessoa, endereco, material);

            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Coletor

        [Fact(DisplayName = "Criar Coletor Com Pessoa Nula")]
        public void CriarColetor_ComPessoaNula_ResultArgumentNullException()
        {
            Endereco endereco = new Endereco("Rua Vai dar Bom", "627", "Brave In", "Gaburincho", "Kyoryugers", "25962314");
            Material material = new Material("Material Teste", "kg", 1);

            Action action = () => new Coletor(null, endereco, material);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "Criar Coletor Com Endereco Nulo")]
        public void CriarColetor_ComEnderecoNulo_ResultArgumentNullException()
        {
            Pessoa pessoa = new Pessoa("Daigo Omura", "65495135782", "16987421680", "daigo.carnival@zyuden.com", new Endereco("Rua Vai dar Bom", "627", "Brave In", "Gaburincho", "Kyoryugers", "25962314"), "foto.jpg");
            Material material = new Material("Material Teste", "kg", 1);

            Action action = () => new Coletor(pessoa, null, material);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "Criar Coletor Com Material Nulo")]
        public void CriarColetor_ComMaterialNulo_ResultArgumentNullException()
        {
            Endereco endereco = new Endereco("Rua Vai dar Bom", "627", "Brave In", "Gaburincho", "Kyoryugers", "25962314");
            Pessoa pessoa = new Pessoa("Daigo Omura", "65495135782", "16987421680", "daigo.carnival@zyuden.com", endereco, "foto.jpg");

            Action action = () => new Coletor(pessoa, endereco, null);

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "Criar Coletor Com CPF Inválido")]
        public void CriarColetor_ComCpfInvalido_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Vai dar Bom", "627", "Brave In", "Gaburincho", "Kyoryugers", "25962314");
            Material material = new Material("Material Teste", "kg", 1);
            Action action = () => new Coletor(new Pessoa("Daigo Omura", "12345", "16987421680", "daigo.carnival@zyuden.com", endereco, "foto.jpg"), endereco, material);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("CPF inválido");
        }

        [Fact(DisplayName = "Criar Coletor Com Email Inválido")]
        public void CriarColetor_ComEmailInvalido_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Vai dar Bom", "627", "Brave In", "Gaburincho", "Kyoryugers", "25962314");
            Material material = new Material("Material Teste", "kg", 1);
            Action action = () => new Coletor(new Pessoa("Daigo Omura", "65495135782", "16987421680", "emailinvalido", endereco, "foto.jpg"), endereco, material);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Email inválido");
        }
        #endregion
    }
}
