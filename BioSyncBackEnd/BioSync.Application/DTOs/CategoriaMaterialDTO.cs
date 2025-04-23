using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class CategoriaMaterialDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MinLength(10, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres")]
        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public string? Descricao { get; set; }
    }
}
