using AutoMapper;
using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAll()
        {
            var usuarioEntity = await _usuarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarioEntity);
        }

        public async Task<UsuarioDTO> GetById(int? id)
        {
            var result = await _usuarioRepository.GetById(id.Value);
            return _mapper.Map<UsuarioDTO>(result);
        }

        public async Task Add(UsuarioDTO dto)
        {
            var entity = _mapper.Map<Usuario>(dto);
            await _usuarioRepository.Create(entity);
        }

        public async Task Update(UsuarioDTO dto)
        {
            var entity = _mapper.Map<Usuario>(dto);
            await _usuarioRepository.Update(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _usuarioRepository.GetById(id.Value);
            await _usuarioRepository.Delete(entity);
        }
    }
}
