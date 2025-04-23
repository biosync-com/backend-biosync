using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface IPontoDescarteService
    {
        Task<IEnumerable<PontoDescarteDTO>> GetAll();
        Task<PontoDescarteDTO> GetById(int? id);
        Task Add(PontoDescarteDTO pontoDescarteDto);
        Task Update(PontoDescarteDTO pontoDescarteDto);
        Task Remove(int? id);
    }
}
