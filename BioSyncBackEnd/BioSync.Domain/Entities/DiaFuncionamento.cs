namespace BioSync.Domain.Entities
{
    public class DiaFuncionamento
    {
        public int Id { get; set; }

        // Dia da semana como texto (ex: "Segunda", "Terça", etc.)
        public string DiaSemana { get; set; }

        // Horário de início do funcionamento
        public TimeSpan HoraInicio { get; set; }

        // Horário de fim do funcionamento
        public TimeSpan HoraFim { get; set; }

        // Chave estrangeira (opcional, se ligada a um ponto de descarte)
        public int PontoDescarteId { get; set; }
        public PontoDescarte PontoDescarte { get; set; }
    }
}
