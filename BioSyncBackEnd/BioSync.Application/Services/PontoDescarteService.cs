using AutoMapper;
using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{
    public class PontoDescarteService : IPontoDescarteService
    {
        private readonly IPontoDescarteRepository _pontoDescarteRepository;
        private readonly IMapper _mapper;

        public PontoDescarteService(IPontoDescarteRepository pontoDescarteRepository, IMapper mapper)
        {
            _pontoDescarteRepository = pontoDescarteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PontoDescarteDTO>> GetAll()
        {
            var pontoDescarteEntity = await _pontoDescarteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PontoDescarteDTO>>(pontoDescarteEntity);
        }

        public async Task<PontoDescarteDTO> GetById(int? id)
        {
            var result = await _pontoDescarteRepository.GetById(id.Value);
            return _mapper.Map<PontoDescarteDTO>(result);
        }

        public async Task Add(PontoDescarteDTO dto)
        {
            var entity = _mapper.Map<PontoDescarte>(dto);
            await _pontoDescarteRepository.Create(entity);
        }

        public async Task Update(PontoDescarteDTO dto)
        {
            var entity = _mapper.Map<PontoDescarte>(dto);
            await _pontoDescarteRepository.Update(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _pontoDescarteRepository.GetById(id.Value);
            await _pontoDescarteRepository.Delete(entity);
        }
    }
}
