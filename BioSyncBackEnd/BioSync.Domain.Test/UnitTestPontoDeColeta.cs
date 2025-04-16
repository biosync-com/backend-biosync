using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;

namespace BioSync.Domain.Entities.Tests
{
    public class PontoDescarteTests
    {
        #region Testes Positivos de Ponto de Descarte

        [Fact(DisplayName = "Criar Ponto de Descarte Com Estado Válido")]
        public void CriarPontoDescarte_ComParametrosValidos_ResultObjetoEstadoValido()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Vitta Ambiental";
            string cpf = "55874135962";
            string cnpj = null; // Ou um CNPJ válido para testar ambos os casos
            string telefone = "1633844554";
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";

            Action action = () => new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Com Dias de Funcionamento Válidos")]
        public void CriarPontoDescarte_ComDiasDeFuncionamentoValidos_ResultObjetoEstadoValido()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Vitta Ambiental";
            string cpf = "55874135962";
            string cnpj = null;
            string telefone = "1633844554";
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";
            List<DiaFuncionamento> diasFuncionamento = new List<DiaFuncionamento>
            {
                new DiaFuncionamento { DiaSemana = "Segunda", HoraInicio = new TimeSpan(8, 0, 0), HoraFim = new TimeSpan(17, 0, 0) },
                new DiaFuncionamento { DiaSemana = "Quarta", HoraInicio = new TimeSpan(8, 0, 0), HoraFim = new TimeSpan(17, 0, 0) },
                new DiaFuncionamento { DiaSemana = "Sexta", HoraInicio = new TimeSpan(8, 0, 0), HoraFim = new TimeSpan(17, 0, 0) }
            };

            PontoDescarte pontoDescarte = new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);
            pontoDescarte.DiasFuncionamento = diasFuncionamento;

            pontoDescarte.Should().NotBeNull();
            pontoDescarte.DiasFuncionamento.Should().NotBeNull();
            pontoDescarte.DiasFuncionamento.Should().HaveCount(3);
            pontoDescarte.DiasFuncionamento.Should().Contain(d => d.DiaSemana == "Segunda");
            pontoDescarte.DiasFuncionamento.Should().Contain(d => d.DiaSemana == "Quarta");
            pontoDescarte.DiasFuncionamento.Should().Contain(d => d.DiaSemana == "Sexta");
        }

        #endregion

        #region Testes Negativos de Ponto de Descarte

        [Fact(DisplayName = "Criar Ponto de Descarte Com Nome Nulo ou Vazio")]
        public void CriarPontoDescarte_ComNomeNuloOuVazio_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string cpf = "55874135962";
            string cnpj = null;
            string telefone = "1633844554";
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";

            Action actionNomeNulo = () => new PontoDescarte(null, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);
            Action actionNomeVazio = () => new PontoDescarte("", cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);

            actionNomeNulo.Should().Throw<DomainExceptionValidation>().WithMessage("Nome é obrigatório");
            actionNomeVazio.Should().Throw<DomainExceptionValidation>().WithMessage("Nome é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Com Nome Muito Curto")]
        public void CriarPontoDescarte_ComNomeMuitoCurto_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Te"; // Nome com menos de 3 caracteres
            string cpf = "55874135962";
            string cnpj = null;
            string telefone = "1633844554";
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";

            Action action = () => new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome muito curto, mínimo 3 caracteres");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Sem CPF e Sem CNPJ")]
        public void CriarPontoDescarte_SemCpfESemCnpj_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Vitta Ambiental";
            string cpf = null;
            string cnpj = null;
            string telefone = "1633844554";
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";

            Action action = () => new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("É necessário fornecer CPF ou CNPJ");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Com CPF Inválido")]
        public void CriarPontoDescarte_ComCpfInvalido_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Vitta Ambiental";
            string cpf = "12345"; // CPF com menos de 11 caracteres
            string cnpj = null;
            string telefone = "1633844554";
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";

            Action action = () => new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("CPF inválido");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Com CNPJ Inválido")]
        public void CriarPontoDescarte_ComCnpjInvalido_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Vitta Ambiental";
            string cpf = null;
            string cnpj = "12345"; // CNPJ com menos de 14 caracteres
            string telefone = "1633844554";
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";

            Action action = () => new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("CNPJ inválido");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Com Telefone Nulo ou Vazio")]
        public void CriarPontoDescarte_ComTelefoneNuloOuVazio_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Vitta Ambiental";
            string cpf = "55874135962";
            string cnpj = null;
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";

            Action actionTelefoneNulo = () => new PontoDescarte(nome, cpf, cnpj, null, emailOuSite, nomeResponsavel, endereco);
            Action actionTelefoneVazio = () => new PontoDescarte(nome, cpf, cnpj, "", emailOuSite, nomeResponsavel, endereco);

            actionTelefoneNulo.Should().Throw<DomainExceptionValidation>().WithMessage("Telefone é obrigatório");
            actionTelefoneVazio.Should().Throw<DomainExceptionValidation>().WithMessage("Telefone é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Com Telefone Inválido")]
        public void CriarPontoDescarte_ComTelefoneInvalido_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Vitta Ambiental";
            string cpf = "55874135962";
            string cnpj = null;
            string telefone = "123"; // Telefone com menos de 10 caracteres
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";

            Action action = () => new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Telefone inválido");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Com EmailOuSite Nulo ou Vazio")]
        public void CriarPontoDescarte_ComEmailOuSiteNuloOuVazio_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Vitta Ambiental";
            string cpf = "55874135962";
            string cnpj = null;
            string telefone = "1633844554";
            string nomeResponsavel = "Renata Sousa";

            Action actionEmailOuSiteNulo = () => new PontoDescarte(nome, cpf, cnpj, telefone, null, nomeResponsavel, endereco);
            Action actionEmailOuSiteVazio = () => new PontoDescarte(nome, cpf, cnpj, telefone, "", nomeResponsavel, endereco);

            actionEmailOuSiteNulo.Should().Throw<DomainExceptionValidation>().WithMessage("Contato por e-mail ou site é obrigatório");
            actionEmailOuSiteVazio.Should().Throw<DomainExceptionValidation>().WithMessage("Contato por e-mail ou site é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Com NomeResponsavel Nulo ou Vazio")]
        public void CriarPontoDescarte_ComNomeResponsavelNuloOuVazio_ResultDomainExceptionValidation()
        {
            Endereco endereco = new Endereco("Rua Teste", "123", "Bairro Teste", "Cidade Teste", "Estado Teste", "12345678");
            string nome = "Vitta Ambiental";
            string cpf = "55874135962";
            string cnpj = null;
            string telefone = "1633844554";
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = null;

            Action actionNomeResponsavelNulo = () => new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, null, endereco);
            Action actionNomeResponsavelVazio = () => new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, "", endereco);

            actionNomeResponsavelNulo.Should().Throw<DomainExceptionValidation>().WithMessage("Nome do responsável é obrigatório");
            actionNomeResponsavelVazio.Should().Throw<DomainExceptionValidation>().WithMessage("Nome do responsável é obrigatório");
        }

        [Fact(DisplayName = "Criar Ponto de Descarte Com Endereco Nulo")]
        public void CriarPontoDescarte_ComEnderecoNulo_ResultDomainExceptionValidation()
        {
            string nome = "Vitta Ambiental";
            string cpf = "55874135962";
            string cnpj = null;
            string telefone = "1633844554";
            string emailOuSite = "teste@teste.com";
            string nomeResponsavel = "Renata Sousa";

            Action action = () => new PontoDescarte(nome, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, null);

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Endereço é obrigatório");
        }

        #endregion
    }
}

