using BioSync.Application.DTOs;

namespace BioSync.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetAll();
        Task<UsuarioDTO> GetById(int? id);
        Task Add(UsuarioDTO usuarioDto);
        Task Update(UsuarioDTO usuarioDto);
        Task Remove(int? id);
    }
}
