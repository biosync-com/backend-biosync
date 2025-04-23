using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface IColetorService
    {
        Task<IEnumerable<ColetorDTO>> GetAll();
        Task<ColetorDTO> GetById(int? id);
        Task Add(ColetorDTO coletorDto);
        Task Update(ColetorDTO coletorDto);
        Task Remove(int? id);
    }
}
