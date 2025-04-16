using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public abstract class Pessoa : Entity
    {
        public string Nome { get; protected set; }
        public string CPF { get; protected set; }
        public string Telefone { get; protected set; }
        public string Email { get; protected set; }

        public int EnderecoId { get; protected set; }
        public Endereco Endereco { get; protected set; }

        public string FotoDocumento { get; protected set; }
        public bool EmailVerificado { get; protected set; }

        protected Pessoa(string nome, string cpf, string telefone, string email, Endereco endereco, string fotoDocumento)
        {
            ValidatePessoa(nome, cpf, telefone, email, endereco, fotoDocumento);
            EmailVerificado = false;
        }

        private void ValidatePessoa(string nome, string cpf, string telefone, string email, Endereco endereco, string fotoDocumento)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            DomainExceptionValidation.When(nome.Length < 3, "Nome muito curto, mínimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf) || cpf.Length != 11, "CPF inválido");

            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Telefone é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email é obrigatório");
            DomainExceptionValidation.When(!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email), "Email inválido");

            DomainExceptionValidation.When(endereco == null, "Endereço é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(fotoDocumento), "Foto de documento é obrigatória");

            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            EnderecoId = endereco.Id;
            FotoDocumento = fotoDocumento;
        }

        public void VerificarEmail()
        {
            EmailVerificado = true;
        }
    }
}
