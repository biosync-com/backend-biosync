using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface INoticiasRepository
    {
        Task<IEnumerable<Noticias>> GetAllAsync();
        Task<Noticias> GetById(int id);
        Task<Noticias> Create(Noticias noticias);
        Task<Noticias> Update(Noticias noticias);
        Task<Noticias> Delete(Noticias noticias);
    }
}
