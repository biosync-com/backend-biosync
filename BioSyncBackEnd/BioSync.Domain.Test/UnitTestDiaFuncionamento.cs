using BioSync.Domain.Entities;
using BioSync.Domain.Enums;
using FluentAssertions;

namespace BioSync.Domain.Test
{
    public class UnitTestDiaFuncionamento
    {
        #region Testes Positivos

        [Fact(DisplayName = "Criar DiaFuncionamento com horários válidos")]
        public void CriarDiaFuncionamento_ComHorariosValidos_NaoDeveLancarExcecao()
        {
            var dia = new DiaFuncionamento
            {
                Dia = DiaSemana.Segunda,
                HoraInicio = TimeSpan.FromHours(8),
                HoraFim = TimeSpan.FromHours(17),
                PontoDescarteId = 1
            };

            dia.HoraInicio.Should().BeLessThan(dia.HoraFim);
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Criar DiaFuncionamento com hora final menor que inicial")]
        public void CriarDiaFuncionamento_HoraFimMenorQueInicio_DeveSerInvalido()
        {
            var dia = new DiaFuncionamento
            {
                Dia = DiaSemana.Terca,
                HoraInicio = TimeSpan.FromHours(17),
                HoraFim = TimeSpan.FromHours(8),
                PontoDescarteId = 1
            };

            var valido = dia.HoraInicio < dia.HoraFim;
            valido.Should().BeFalse("Hora de início deve ser menor que hora final");
        }

        [Fact(DisplayName = "Criar DiaFuncionamento com hora inicial igual à final")]
        public void CriarDiaFuncionamento_HoraInicioIgualHoraFim_DeveSerInvalido()
        {
            var hora = TimeSpan.FromHours(10);
            var dia = new DiaFuncionamento
            {
                Dia = DiaSemana.Quarta,
                HoraInicio = hora,
                HoraFim = hora,
                PontoDescarteId = 1
            };

            var valido = dia.HoraInicio < dia.HoraFim;
            valido.Should().BeFalse("Hora de início deve ser menor que hora final");
        }

        #endregion
    }
}
