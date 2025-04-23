using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface IConteudosRepository
    {
        Task<IEnumerable<Conteudos>> GetAllAsync();
        Task<Conteudos> GetById(int id);
        Task<Conteudos> Create(Conteudos conteudos);
        Task<Conteudos> Update(Conteudos conteudos);
        Task<Conteudos> Delete(Conteudos conteudos);
    }
}
