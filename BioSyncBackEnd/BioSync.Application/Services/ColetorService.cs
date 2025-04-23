using AutoMapper;
using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{
    public class ColetorService : IColetorService
    {
        private readonly IColetorRepository _coletorRepository; 
        private readonly IMapper _mapper;

        public ColetorService(IColetorRepository coletorRepository, IMapper mapper) 
        {
            _coletorRepository = coletorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ColetorDTO>> GetAll()
        {
            var coletorEntity = await _coletorRepository.GetAllAsync(); 
            return _mapper.Map<IEnumerable<ColetorDTO>>(coletorEntity);
        }

        public async Task<ColetorDTO> GetById(int? id)
        {
            var result = await _coletorRepository.GetById(id.Value); 
            return _mapper.Map<ColetorDTO>(result);
        }

        public async Task Add(ColetorDTO dto)
        {
            var entity = _mapper.Map<Coletor>(dto);
            await _coletorRepository.Create(entity); 
        }

        public async Task Update(ColetorDTO dto)
        {
            var entity = _mapper.Map<Coletor>(dto);
            await _coletorRepository.Update(entity); 
        }

        public async Task Remove(int? id)
        {
            var entity = await _coletorRepository.GetById(id.Value); 
            await _coletorRepository.Delete(entity); 
        }
    }
}
