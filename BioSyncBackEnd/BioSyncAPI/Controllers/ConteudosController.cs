using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteudosController : ControllerBase
    {
        private readonly IConteudosService _conteudoService;

        public ConteudosController(IConteudosService conteudoService)
        {
            _conteudoService = conteudoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConteudosDTO>>> GetAll()
        {
            try
            {
                var conteudos = await _conteudoService.GetAll();
                return Ok(conteudos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConteudosDTO>> GetById(int id)
        {
            try
            {
                var conteudo = await _conteudoService.GetById(id);
                if (conteudo == null)
                {
                    return NotFound($"Conteúdo com ID {id} não encontrado.");
                }
                return Ok(conteudo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Add(ConteudosDTO conteudoDto)
        {
            try
            {
                await _conteudoService.Add(conteudoDto);
                return CreatedAtAction(nameof(GetById), new { id = conteudoDto.Id }, conteudoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Update(int id, ConteudosDTO conteudoDto)
        {
            if (id != conteudoDto.Id)
            {
                return BadRequest("ID não corresponde ao ID da entidade.");
            }

            try
            {
                var conteudoExistente = await _conteudoService.GetById(id);
                if (conteudoExistente == null)
                {
                    return NotFound($"Conteúdo com ID {id} não encontrado.");
                }
                await _conteudoService.Update(conteudoDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                var conteudoExistente = await _conteudoService.GetById(id);
                if (conteudoExistente == null)
                {
                    return NotFound($"Conteúdo com ID {id} não encontrado.");
                }
                await _conteudoService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
