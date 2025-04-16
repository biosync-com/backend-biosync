using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<AgendamentoDTO>> GetAll();
        Task<AgendamentoDTO> GetById(int? id);
        Task Add(AgendamentoDTO agendamentoDto);
        Task Update(AgendamentoDTO agendamentoDto);
        Task Remove(int? id);
    }
}
