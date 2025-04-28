using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class CategoriaMaterial : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public ICollection<Material> Materiais { get; private set; }

        public CategoriaMaterial(int id,string nome, string descricao)
        {
            Id = id;
            ValidateDomain(nome, descricao);
            Materiais = new List<Material>();
        }

        private void ValidateDomain(string nome, string descricao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome da categoria é obrigatório");
            DomainExceptionValidation.When(nome.Length < 3,
                "Nome muito curto, mínimo 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descrição é obrigatória");
            DomainExceptionValidation.When(descricao.Length < 10,
                "Descrição muito curta, mínimo 10 caracteres");

            Nome = nome;
            Descricao = descricao;
        }
    }
}
