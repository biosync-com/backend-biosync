using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface INoticiasService
    {
        Task<IEnumerable<NoticiasDTO>> GetAll();
        Task<NoticiasDTO> GetById(int? id);
        Task Add(NoticiasDTO noticiasDto);
        Task Update(NoticiasDTO noticiasDto);
        Task Remove(int? id);
    }
}
