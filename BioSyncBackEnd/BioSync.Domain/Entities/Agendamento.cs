using BioSync.Domain.Entities;
using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{   
    public class Agendamento : Entity
    {
        public DateTime Data { get; set; }
        public TimeSpan HoraInicioDisponivel { get; set; }
        public TimeSpan HoraFimDisponivel { get; set; }
        public string Status { get; set; }
        public decimal PesoEstimadoKg { get; set; }
        public string FotoResiduos { get; set; }
        public string Observacoes { get; set; }

    // Relacionamentos futuros
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int? ColetorId { get; set; } // Caso seja aceito por um coletor
        public Coletor? Coletor { get; set; }

    // Lista de materiais incluídos neste agendamento
        public ICollection<Material>? Materiais { get; set; }

        public Agendamento(DateTime data, TimeSpan horaInicioDisponivel, TimeSpan horaFimDisponivel,
                       decimal pesoEstimadoKg, string fotoResiduos, string observacoes)
        {
            ValidateDomain(data, horaInicioDisponivel, horaFimDisponivel, pesoEstimadoKg, fotoResiduos, observacoes);
            Status = "Pendente";
        }

        private void ValidateDomain(DateTime data, TimeSpan horaInicioDisponivel, TimeSpan horaFimDisponivel,
                                decimal pesoEstimadoKg, string fotoResiduos, string observacoes)
        {
            DomainExceptionValidation.When(data.Date < DateTime.Now.Date,
            "Data do agendamento não pode ser no passado");
            DomainExceptionValidation.When(horaInicioDisponivel >= horaFimDisponivel,
            "Hora inicial deve ser menor que a hora final");
            DomainExceptionValidation.When(pesoEstimadoKg <= 0,
            "Peso estimado deve ser maior que zero");
            DomainExceptionValidation.When(string.IsNullOrEmpty(fotoResiduos),
            "Foto dos resíduos é obrigatória");
            DomainExceptionValidation.When(fotoResiduos.Length > 250,
            "URL da foto muito longa, máximo 250 caracteres");

            Data = data;
            HoraInicioDisponivel = horaInicioDisponivel;
            HoraFimDisponivel = horaFimDisponivel;
            PesoEstimadoKg = pesoEstimadoKg;
            FotoResiduos = fotoResiduos;
            Observacoes = observacoes;
        }

        public void Cancelar() => Status = "Cancelado";

        public void Concluir() => Status = "Concluído";
    }
}