using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
        public class Coletor : Entity
        {
            public string Nome { get; set; }
            public string CPF { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
            public string Endereco { get; set; }
            public DateTime DataCadastro { get; set; }

            public Coletor(string nome, string cpf, string telefone, string email, string endereco)
            {
                ValidateDomain(nome, cpf, telefone, email, endereco);
                DataCadastro = DateTime.Now;
            }

            private void ValidateDomain(string nome, string cpf, string telefone, string email, string endereco)
            {
                DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
                DomainExceptionValidation.When(nome.Length < 3, "Nome muito curto, mínimo 3 caracteres");
                DomainExceptionValidation.When(string.IsNullOrEmpty(cpf) || cpf.Length != 11, "CPF inválido");
                DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Telefone é obrigatório");
                DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email é obrigatório");
                DomainExceptionValidation.When(!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email), "Email inválido");
                DomainExceptionValidation.When(string.IsNullOrEmpty(endereco), "Endereço é obrigatório");

                Nome = nome;
                CPF = cpf;
                Telefone = telefone;
                Email = email;
                Endereco = endereco;
            }
        }
}


