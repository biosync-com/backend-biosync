using BioSync.Domain.Entities;
using BioSync.Domain.Validation;
using FluentAssertions;

namespace BioSync.Domain.Tests
{
    public class AgendamentoTests
    {
        #region Testes Positivos

        [Fact(DisplayName = "Criar Agendamento com dados válidos")]
        public void CriarAgendamento_ComDadosValidos_NaoDeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                DateTime.Now.AddDays(1),
                TimeSpan.FromHours(10),
                TimeSpan.FromHours(12),
                10.5m,
                "https://imagem.com/foto.jpg",
                "Deixar os materiais no portão");

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Cancelar agendamento deve mudar status para 'Cancelado'")]
        public void CancelarAgendamento_DeveAtualizarStatus()
        {
            var agendamento = CriarAgendamentoValido();

            agendamento.Cancelar();

            agendamento.Status.Should().Be("Cancelado");
        }

        [Fact(DisplayName = "Concluir agendamento deve mudar status para 'Concluído'")]
        public void ConcluirAgendamento_DeveAtualizarStatus()
        {
            var agendamento = CriarAgendamentoValido();

            agendamento.Concluir();

            agendamento.Status.Should().Be("Concluído");
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar Agendamento com data no passado deve lançar exceção")]
        public void CriarAgendamento_ComDataPassada_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                DateTime.Now.AddDays(-1),
                TimeSpan.FromHours(10),
                TimeSpan.FromHours(12),
                10,
                "foto.jpg",
                "Observação");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Data do agendamento não pode ser no passado");
        }

        [Fact(DisplayName = "Criar Agendamento com hora inicial maior ou igual à final deve lançar exceção")]
        public void CriarAgendamento_ComHorarioInvalido_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                DateTime.Now.AddDays(1),
                TimeSpan.FromHours(12),
                TimeSpan.FromHours(10),
                10,
                "foto.jpg",
                "Obs");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Hora inicial deve ser menor que a hora final");
        }

        [Fact(DisplayName = "Criar Agendamento com peso estimado <= 0 deve lançar exceção")]
        public void CriarAgendamento_ComPesoInvalido_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                DateTime.Now.AddDays(1),
                TimeSpan.FromHours(10),
                TimeSpan.FromHours(12),
                0,
                "foto.jpg",
                "Obs");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Peso estimado deve ser maior que zero");
        }

        [Fact(DisplayName = "Criar Agendamento com foto vazia deve lançar exceção")]
        public void CriarAgendamento_ComFotoVazia_DeveLancarExcecao()
        {
            Action action = () => new Agendamento(
                DateTime.Now.AddDays(1),
                TimeSpan.FromHours(10),
                TimeSpan.FromHours(12),
                10,
                "",
                "Obs");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Foto dos resíduos é obrigatória");
        }

        [Fact(DisplayName = "Criar Agendamento com URL de foto muito longa deve lançar exceção")]
        public void CriarAgendamento_ComFotoMuitoLonga_DeveLancarExcecao()
        {
            var longUrl = new string('a', 251);

            Action action = () => new Agendamento(
                DateTime.Now.AddDays(1),
                TimeSpan.FromHours(10),
                TimeSpan.FromHours(12),
                10,
                longUrl,
                "Obs");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("URL da foto muito longa, máximo 250 caracteres");
        }

        [Fact(DisplayName = "Criar Agendamento com observações muito longas deve lançar exceção")]
        public void CriarAgendamento_ComObservacoesMuitoLongas_DeveLancarExcecao()
        {
            var obsLonga = new string('x', 501);

            Action action = () => new Agendamento(
                DateTime.Now.AddDays(1),
                TimeSpan.FromHours(10),
                TimeSpan.FromHours(12),
                10,
                "foto.jpg",
                obsLonga);

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Observações muito longas, máximo 500 caracteres.");
        }


        #endregion

        #region Método de Apoio

        private Agendamento CriarAgendamentoValido() =>
            new Agendamento(
                DateTime.Now.AddDays(1),
                TimeSpan.FromHours(8),
                TimeSpan.FromHours(10),
                7,
                "foto.jpg",
                "Portão estará aberto");

        #endregion
    }
}
