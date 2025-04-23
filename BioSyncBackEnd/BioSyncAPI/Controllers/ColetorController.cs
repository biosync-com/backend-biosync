using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColetorController : ControllerBase
    {
        private readonly IColetorService _coletorService;

        public ColetorController(IColetorService coletorService)
        {
            _coletorService = coletorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColetorDTO>>> GetAll()
        {
            try
            {
                var coletores = await _coletorService.GetAll();
                return Ok(coletores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColetorDTO>> GetById(int id)
        {
            try
            {
                var coletor = await _coletorService.GetById(id);
                if (coletor == null)
                {
                    return NotFound($"Coletor com ID {id} não encontrado.");
                }
                return Ok(coletor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(ColetorDTO coletorDto)
        {
            try
            {
                await _coletorService.Add(coletorDto);
                return CreatedAtAction(nameof(GetById), new { id = coletorDto.Id }, coletorDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ColetorDTO coletorDto)
        {
            if (id != coletorDto.Id)
            {
                return BadRequest("ID não corresponde ao ID da entidade.");
            }

            try
            {
                var coletorExistente = await _coletorService.GetById(id);
                if (coletorExistente == null)
                {
                    return NotFound($"Coletor com ID {id} não encontrado.");
                }
                await _coletorService.Update(coletorDto);
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
                var coletorExistente = await _coletorService.GetById(id);
                if (coletorExistente == null)
                {
                    return NotFound($"Coletor com ID {id} não encontrado.");
                }
                await _coletorService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
