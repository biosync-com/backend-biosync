using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface IConteudosService
    {
        Task<IEnumerable<ConteudosDTO>> GetAll();
        Task<ConteudosDTO> GetById(int? id);
        Task Add(ConteudosDTO conteudosDto);
        Task Update(ConteudosDTO conteudosDto);
        Task Remove(int? id);
    }
}
