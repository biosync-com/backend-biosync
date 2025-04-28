using BioSync.Domain.Entities;

namespace BioSync.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByEmailAsync(string email);
        Task<Usuario> GetById(int id);
        Task<Usuario> Create(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task<Usuario> Delete(Usuario usuario);

    }
}
