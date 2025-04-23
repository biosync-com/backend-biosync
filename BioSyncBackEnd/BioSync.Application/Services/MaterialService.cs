using AutoMapper;
using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaterialDTO>> GetAll()
        {
            var materialEntity = await _materialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaterialDTO>>(materialEntity);
        }

        public async Task<MaterialDTO> GetById(int? id)
        {
            var result = await _materialRepository.GetById(id.Value);
            return _mapper.Map<MaterialDTO>(result);
        }

        public async Task Add(MaterialDTO dto)
        {
            var entity = _mapper.Map<Material>(dto);
            await _materialRepository.Create(entity);
        }

        public async Task Update(MaterialDTO dto)
        {
            var entity = _mapper.Map<Material>(dto);
            await _materialRepository.Update(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _materialRepository.GetById(id.Value);
            await _materialRepository.Delete(entity);
        }
    }
}
