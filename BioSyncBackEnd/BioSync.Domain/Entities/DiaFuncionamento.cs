using BioSync.Domain.Enums;
using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class DiaFuncionamento : Entity
    {

        public DiaSemana Dia { get; set; }

        public TimeSpan HoraInicio { get; set; }

        public TimeSpan HoraFim { get; set; }

        public int PontoDescarteId { get; set; }
        public PontoDescarte PontoDescarte { get; set; }
     
     
    }
}
