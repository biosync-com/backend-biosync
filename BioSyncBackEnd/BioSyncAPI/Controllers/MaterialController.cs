using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDTO>>> GetAll()
        {
            try
            {
                var materiais = await _materialService.GetAll();
                return Ok(materiais);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialDTO>> GetById(int id)
        {
            try
            {
                var material = await _materialService.GetById(id);
                if (material == null)
                {
                    return NotFound($"Material com ID {id} não encontrado.");
                }
                return Ok(material);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(MaterialDTO materialDto)
        {
            try
            {
                await _materialService.Add(materialDto);
                return CreatedAtAction(nameof(GetById), new { id = materialDto.Id }, materialDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, MaterialDTO materialDto)
        {
            if (id != materialDto.Id)
            {
                return BadRequest("ID não corresponde ao ID da entidade.");
            }

            try
            {
                var materialExistente = await _materialService.GetById(id);
                if (materialExistente == null)
                {
                    return NotFound($"Material com ID {id} não encontrado.");
                }
                await _materialService.Update(materialDto);
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
                var materialExistente = await _materialService.GetById(id);
                if (materialExistente == null)
                {
                    return NotFound($"Material com ID {id} não encontrado.");
                }
                await _materialService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
