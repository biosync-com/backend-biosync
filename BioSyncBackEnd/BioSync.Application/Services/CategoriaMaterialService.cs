using AutoMapper;
using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{
    public class CategoriaMaterialService : ICategoriaMaterialService
    {
        private readonly ICategoriaMaterialRepository _categoriaMaterialRepository;
        private readonly IMapper _mapper;

        public CategoriaMaterialService(ICategoriaMaterialRepository categoriaMaterialRepository, IMapper mapper)
        {
            _categoriaMaterialRepository = categoriaMaterialRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaMaterialDTO>> GetAll()
        {
            var categoriaMaterialEntity = await _categoriaMaterialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaMaterialDTO>>(categoriaMaterialEntity);
        }

        public async Task<CategoriaMaterialDTO> GetById(int? id)
        {
            var result = await _categoriaMaterialRepository.GetById(id.Value);
            return _mapper.Map<CategoriaMaterialDTO>(result);
        }

        public async Task Add(CategoriaMaterialDTO dto)
        {
            var entity = _mapper.Map<CategoriaMaterial>(dto);
            await _categoriaMaterialRepository.Create(entity);
        }

        public async Task Update(CategoriaMaterialDTO dto)
        {
            var entity = _mapper.Map<CategoriaMaterial>(dto);
            await _categoriaMaterialRepository.Update(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _categoriaMaterialRepository.GetById(id.Value);
            await _categoriaMaterialRepository.Delete(entity);
        }
    }
}
