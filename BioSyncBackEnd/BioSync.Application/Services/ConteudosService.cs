using AutoMapper;
using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{
    public class ConteudosService : IConteudosService
    {
        private readonly IConteudosRepository _conteudosRepository;
        private readonly IMapper _mapper;

        public ConteudosService(IConteudosRepository conteudosRepository, IMapper mapper)
        {
            _conteudosRepository = conteudosRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConteudosDTO>> GetAll()
        {
            var conteudosEntity = await _conteudosRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ConteudosDTO>>(conteudosEntity);
        }

        public async Task<ConteudosDTO> GetById(int? id)
        {
            var result = await _conteudosRepository.GetById(id.Value);
            return _mapper.Map<ConteudosDTO>(result);
        }

        public async Task Add(ConteudosDTO dto)
        {
            var entity = _mapper.Map<Conteudos>(dto);
            await _conteudosRepository.Create(entity);
        }

        public async Task Update(ConteudosDTO dto)
        {
            var entity = _mapper.Map<Conteudos>(dto);
            await _conteudosRepository.Update(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _conteudosRepository.GetById(id.Value);
            await _conteudosRepository.Delete(entity);
        }
    }
}
