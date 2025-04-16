using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class MaterialDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do material é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome do material deve ter no mínimo 3 caracteres")]
        [MaxLength(150, ErrorMessage = "O nome do material não pode ter mais de 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A categoria do material é obrigatória")]
        public int CategoriaMaterialId { get; set; }

        public MaterialDTO(int id, string nome, int categoriaMaterialId)
        {
            Id = id;
            Nome = nome;
            CategoriaMaterialId = categoriaMaterialId;
        }
    }
}
