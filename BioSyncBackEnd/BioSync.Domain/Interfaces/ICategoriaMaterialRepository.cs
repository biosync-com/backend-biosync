using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface ICategoriaMaterialRepository
    {
        Task<IEnumerable<CategoriaMaterial>> GetAllAsync();
        Task<CategoriaMaterial> GetById(int id);
        Task<CategoriaMaterial> Create(CategoriaMaterial categoria);
        Task<CategoriaMaterial> Update(CategoriaMaterial categoria);
        Task<CategoriaMaterial> Delete(CategoriaMaterial categoria);
    }
}
