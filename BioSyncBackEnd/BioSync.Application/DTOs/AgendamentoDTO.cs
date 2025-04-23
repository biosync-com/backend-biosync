using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class AgendamentoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data do agendamento é obrigatória")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "A hora de início da disponibilidade é obrigatória")]
        public TimeSpan HoraInicioDisponivel { get; set; }

        [Required(ErrorMessage = "A hora de fim da disponibilidade é obrigatória")]
        public TimeSpan HoraFimDisponivel { get; set; }

        [Required(ErrorMessage = "O status do agendamento é obrigatório")]
        [MaxLength(20, ErrorMessage = "O status não pode ter mais que 20 caracteres")]
        public string Status { get; set; }

        [Required(ErrorMessage = "O peso estimado é obrigatório")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O peso estimado deve ser maior que zero")]
        public decimal PesoEstimadoKg { get; set; }

        [Required(ErrorMessage = "A foto dos resíduos é obrigatória")]
        [MaxLength(250, ErrorMessage = "A URL da foto não pode ter mais que 250 caracteres")]
        public string FotoResiduos { get; set; }

        [MaxLength(500, ErrorMessage = "As observações não podem exceder 500 caracteres")]
        public string? Observacoes { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório")]
        public int UsuarioId { get; set; }

        public int? ColetorId { get; set; }

        public ICollection<int>? MateriaisIds { get; set; }

        public AgendamentoDTO(DateTime data, TimeSpan horaInicioDisponivel, TimeSpan horaFimDisponivel,
                              decimal pesoEstimadoKg, string fotoResiduos, string observacoes)
        {
            Data = data;
            HoraInicioDisponivel = horaInicioDisponivel;
            HoraFimDisponivel = horaFimDisponivel;
            PesoEstimadoKg = pesoEstimadoKg;
            FotoResiduos = fotoResiduos;
            Observacoes = observacoes;
            Status = "Pendente"; 
        }
    }
}
