using BioSync.Application.DTOs;
using BioSync.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BioSync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaMaterialController : ControllerBase
    {
        private readonly ICategoriaMaterialService _categoriaMaterialService;

        public CategoriaMaterialController(ICategoriaMaterialService categoriaMaterialService)
        {
            _categoriaMaterialService = categoriaMaterialService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaMaterialDTO>>> GetAll()
        {
            try
            {
                var categoriaMaterials = await _categoriaMaterialService.GetAll();
                return Ok(categoriaMaterials);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaMaterialDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest("O ID da categoria de material não foi fornecido.");
            }

            try
            {
                var categoriaMaterial = await _categoriaMaterialService.GetById(id);
                if (categoriaMaterial == null)
                {
                    return NotFound($"Categoria de material com ID {id} não encontrada.");
                }

                return Ok(categoriaMaterial);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        
        [HttpPost]
        public async Task<ActionResult> Add(CategoriaMaterialDTO categoriaMaterialDto)
        {
            if (categoriaMaterialDto == null)
            {
                return BadRequest("Dados da categoria de material inválidos.");
            }

            try
            {
                await _categoriaMaterialService.Add(categoriaMaterialDto);
                return CreatedAtAction(nameof(GetById), new { id = categoriaMaterialDto.Id }, categoriaMaterialDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CategoriaMaterialDTO categoriaMaterialDto)
        {
            if (id != categoriaMaterialDto.Id)
            {
                return BadRequest("ID da categoria de material não coincide com o ID fornecido.");
            }

            try
            {
                var existingCategoriaMaterial = await _categoriaMaterialService.GetById(id);
                if (existingCategoriaMaterial == null)
                {
                    return NotFound($"Categoria de material com ID {id} não encontrada.");
                }

                await _categoriaMaterialService.Update(categoriaMaterialDto);
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
                var categoriaMaterial = await _categoriaMaterialService.GetById(id);
                if (categoriaMaterial == null)
                {
                    return NotFound($"Categoria de material com ID {id} não encontrada.");
                }

                await _categoriaMaterialService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex.Message}");
            }
        }
    }
}
