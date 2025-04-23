using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PontoDescarteController : ControllerBase
    {
        private readonly IPontoDescarteService _pontoDescarteService;

        public PontoDescarteController(IPontoDescarteService pontoDescarteService)
        {
            _pontoDescarteService = pontoDescarteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PontoDescarteDTO>>> GetAll()
        {
            try
            {
                var pontos = await _pontoDescarteService.GetAll();
                return Ok(pontos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PontoDescarteDTO>> GetById(int id)
        {
            try
            {
                var ponto = await _pontoDescarteService.GetById(id);
                if (ponto == null)
                {
                    return NotFound($"Ponto de descarte com ID {id} não encontrado.");
                }
                return Ok(ponto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(PontoDescarteDTO pontoDto)
        {
            try
            {
                await _pontoDescarteService.Add(pontoDto);
                return CreatedAtAction(nameof(GetById), new { id = pontoDto.Id }, pontoDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PontoDescarteDTO pontoDto)
        {
            if (id != pontoDto.Id)
            {
                return BadRequest("ID não corresponde ao ID da entidade.");
            }

            try
            {
                var pontoExistente = await _pontoDescarteService.GetById(id);
                if (pontoExistente == null)
                {
                    return NotFound($"Ponto de descarte com ID {id} não encontrado.");
                }
                await _pontoDescarteService.Update(pontoDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                var pontoExistente = await _pontoDescarteService.GetById(id);
                if (pontoExistente == null)
                {
                    return NotFound($"Ponto de descarte com ID {id} não encontrado.");
                }
                await _pontoDescarteService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
