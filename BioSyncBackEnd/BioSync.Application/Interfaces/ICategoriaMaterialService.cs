using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface ICategoriaMaterialService
    {
        Task<IEnumerable<CategoriaMaterialDTO>> GetAll();
        Task<CategoriaMaterialDTO> GetById(int? id);
        Task Add(CategoriaMaterialDTO categoriaMaterialDto);
        Task Update(CategoriaMaterialDTO categoriaMaterialDto);
        Task Remove(int? id);
    }
}
