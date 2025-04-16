using AutoMapper;
using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{
    public class NoticiasService : INoticiasService
    {
        private readonly INoticiasRepository _noticiasRepository;
        private readonly IMapper _mapper;

        public NoticiasService(INoticiasRepository noticiasRepository, IMapper mapper)
        {
            _noticiasRepository = noticiasRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoticiasDTO>> GetAll()
        {
            var noticiasEntity = await _noticiasRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<NoticiasDTO>>(noticiasEntity);
        }

        public async Task<NoticiasDTO> GetById(int? id)
        {
            var result = await _noticiasRepository.GetById(id.Value);
            return _mapper.Map<NoticiasDTO>(result);
        }

        public async Task Add(NoticiasDTO dto)
        {
            var entity = _mapper.Map<Noticias>(dto);
            await _noticiasRepository.Create(entity);
        }

        public async Task Update(NoticiasDTO dto)
        {
            var entity = _mapper.Map<Noticias>(dto);
            await _noticiasRepository.Update(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _noticiasRepository.GetById(id.Value);
            await _noticiasRepository.Delete(entity);
        }
    }
}
