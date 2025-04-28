using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAll()
        {
            try
            {
                var usuarios = await _usuarioService.GetAll();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetById(id);
                if (usuario == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Add(UsuarioDTO usuarioDto)
        {
            try
            {
                await _usuarioService.Add(usuarioDto);
                return CreatedAtAction(nameof(GetById), new { id = usuarioDto.Id }, usuarioDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Update(int id, UsuarioDTO usuarioDto)
        {
            if (id != usuarioDto.Id)
            {
                return BadRequest("ID não corresponde ao ID da entidade.");
            }

            try
            {
                var usuarioExistente = await _usuarioService.GetById(id);
                if (usuarioExistente == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }
                await _usuarioService.Update(usuarioDto);
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
                var usuarioExistente = await _usuarioService.GetById(id);
                if (usuarioExistente == null)
                {
                    return NotFound($"Usuário com ID {id} não encontrado.");
                }
                await _usuarioService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
