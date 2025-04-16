using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using BioSync.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        private readonly INoticiasService _noticiasService;

        public NoticiasController(INoticiasService noticiasService)
        {
            _noticiasService = (NoticiasService?)noticiasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoticiasDTO>>> GetAll()
        {
            try
            {
                var noticias = await _noticiasService.GetAll();
                return Ok(noticias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoticiasDTO>> GetById(int id)
        {
            try
            {
                var noticia = await _noticiasService.GetById(id);
                if (noticia == null)
                {
                    return NotFound($"Notícia com ID {id} não encontrada.");
                }
                return Ok(noticia);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(NoticiasDTO noticiaDto)
        {
            try
            {
                await _noticiasService.Add(noticiaDto);
                return CreatedAtAction(nameof(GetById), new { id = noticiaDto.Id }, noticiaDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, NoticiasDTO noticiaDto)
        {
            if (id != noticiaDto.Id)
            {
                return BadRequest("ID não corresponde ao ID da entidade.");
            }

            try
            {
                var noticiaExistente = await _noticiasService.GetById(id);
                if (noticiaExistente == null)
                {
                    return NotFound($"Notícia com ID {id} não encontrada.");
                }
                await _noticiasService.Update(noticiaDto);
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
                var noticiaExistente = await _noticiasService.GetById(id);
                if (noticiaExistente == null)
                {
                    return NotFound($"Notícia com ID {id} não encontrada.");
                }
                await _noticiasService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
