using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioSync.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentoController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        // GET: api/Agendamento
        [Authorize(Roles = "Usuario,Coletor")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoDTO>>> GetAll()
        {
            try
            {
                var agendamentos = await _agendamentoService.GetAll();
                return Ok(agendamentos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        // GET: api/Agendamento/{id}
        [Authorize(Roles = "Usuario,Coletor")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest("O ID do agendamento não foi fornecido.");
            }

            try
            {
                var agendamento = await _agendamentoService.GetById(id);
                if (agendamento == null)
                {
                    return NotFound($"Agendamento com ID {id} não encontrado.");
                }

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        // POST: api/Agendamento
        [Authorize(Roles = "Usuario")]
        [HttpPost]
        public async Task<ActionResult> Add(AgendamentoDTO agendamentoDto)
        {
            if (agendamentoDto == null)
            {
                return BadRequest("Dados de agendamento inválidos.");
            }

            try
            {
                await _agendamentoService.Add(agendamentoDto);
                return CreatedAtAction(nameof(GetById), new { id = agendamentoDto.Id }, agendamentoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        // PUT: api/Agendamento/{id}
        [Authorize(Roles = "Usuario")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AgendamentoDTO agendamentoDto)
        {
            if (id != agendamentoDto.Id)
            {
                return BadRequest("ID do agendamento não coincide com o ID fornecido.");
            }

            try
            {
                var existingAgendamento = await _agendamentoService.GetById(id);
                if (existingAgendamento == null)
                {
                    return NotFound($"Agendamento com ID {id} não encontrado.");
                }

                await _agendamentoService.Update(agendamentoDto);
                return NoContent(); // Sucesso, mas sem conteúdo para retornar.
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        // DELETE: api/Agendamento/{id}
        [Authorize(Roles = "Usuario")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                var agendamento = await _agendamentoService.GetById(id);
                if (agendamento == null)
                {
                    return NotFound($"Agendamento com ID {id} não encontrado.");
                }

                await _agendamentoService.Remove(id);
                return NoContent(); // Sucesso, mas sem conteúdo para retornar.
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
