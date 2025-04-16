using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<IEnumerable<Agendamento>> GetAllAsync();
        Task<Agendamento> GetById(int id);
        Task<Agendamento> Create(Agendamento agendamento);
        Task<Agendamento> Update(Agendamento agendamento);
        Task<Agendamento> Delete(Agendamento agendamento);
    }
}
