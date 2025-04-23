using AutoMapper;
using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Domain.Entities;
using BioSync.Domain.Interfaces;

namespace BioSync.Application.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IMapper _mapper;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IMapper mapper)
        {
            _agendamentoRepository = agendamentoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgendamentoDTO>> GetAll()
        {
            var agendamentoEntity = await _agendamentoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AgendamentoDTO>>(agendamentoEntity);
        }

        public async Task<AgendamentoDTO> GetById(int? id)
        {
            var result = await _agendamentoRepository.GetById(id.Value);
            return _mapper.Map<AgendamentoDTO>(result);
        }

        public async Task Add(AgendamentoDTO dto)
        {
            var entity = _mapper.Map<Agendamento>(dto);
            await _agendamentoRepository.Create(entity);
        }

        public async Task Update(AgendamentoDTO dto)
        {
            var entity = _mapper.Map<Agendamento>(dto);
            await _agendamentoRepository.Update(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _agendamentoRepository.GetById(id.Value);
            await _agendamentoRepository.Delete(entity);
        }
    }
}
