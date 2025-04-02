using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Material : Entity
    {
        public string Nome { get; set; }
        public string UnidadeMedida { get; set; }
        public bool EhReciclavel { get; set; }
        public int CategoriaMaterialId { get; set; }
        public Material(string nome, string unidadeMedida, bool ehReciclavel, int categoriaMaterialId)
        {
            ValidateDomain(nome, unidadeMedida, categoriaMaterialId);
            EhReciclavel = ehReciclavel;
        }

        private void ValidateDomain(string nome, string unidadeMedida, int categoriaMaterialId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome do material é obrigatório");
            DomainExceptionValidation.When(nome.Length < 3,
                "Nome muito curto, mínimo 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(unidadeMedida),
                "Unidade de medida é obrigatória");
            DomainExceptionValidation.When(categoriaMaterialId <= 0,
                "Categoria do material é obrigatória");

            Nome = nome;
            UnidadeMedida = unidadeMedida;
            CategoriaMaterialId = categoriaMaterialId;
        }
    }


}

