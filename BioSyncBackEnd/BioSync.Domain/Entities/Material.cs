using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Material : Entity
    {
        public string Nome { get; private set; }
        public int CategoriaMaterialId { get; private set; }
        public CategoriaMaterial CategoriaMaterial { get; private set; }

        public Material(string nome, int categoriaMaterialId)
        {
            ValidateDomain(nome, categoriaMaterialId);
        }

        private void ValidateDomain(string nome, int categoriaMaterialId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome do material é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
                "Nome muito curto, mínimo 3 caracteres");

            DomainExceptionValidation.When(categoriaMaterialId <= 0,
                "Categoria do material inválida");

            Nome = nome;
            CategoriaMaterialId = categoriaMaterialId;
        }
    }
}
