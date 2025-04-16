using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Material : Entity
    {
        public string Nome { get; private set; }
        public string UnidadeMedida { get; private set; }

        // Relacionamento com Categoria
        public int CategoriaMaterialId { get; private set; }
        public CategoriaMaterial CategoriaMaterial { get; private set; }

        public Material(string nome, string unidadeMedida, int categoriaMaterialId)
        {
            ValidateDomain(nome, unidadeMedida);
            CategoriaMaterialId = categoriaMaterialId;
        }

        private void ValidateDomain(string nome, string unidadeMedida)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome do material é obrigatório");
            DomainExceptionValidation.When(nome.Length < 3,
                "Nome muito curto, mínimo 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(unidadeMedida),
                "Unidade de medida é obrigatória");

            Nome = nome;
            UnidadeMedida = unidadeMedida;
        }
    }
}
