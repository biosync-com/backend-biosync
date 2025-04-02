using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get;  set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; private set; }
        public string FotoDocumento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool EmailVerificado { get; set; }
        public TipoUsuario Tipo { get; set; }

        public Usuario(string nome, string email, string senha, string cpf, string telefone,
                      string endereco, string fotoDocumento, TipoUsuario tipo)
        {
            ValidateDomain(nome, email, senha, cpf, telefone, endereco, fotoDocumento);
            Tipo = tipo;
            DataCadastro = DateTime.Now;
            EmailVerificado = false;
           
        }

        private void ValidateDomain(string nome, string email, string senha, string cpf,
                                  string telefone, string endereco, string fotoDocumento)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            DomainExceptionValidation.When(nome.Length < 3, "Nome muito curto, mínimo 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email é obrigatório");
            DomainExceptionValidation.When(!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(email), "Email inválido");
            DomainExceptionValidation.When(string.IsNullOrEmpty(senha), "Senha é obrigatória");
            DomainExceptionValidation.When(senha.Length < 8, "Senha muito curta, mínimo 8 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf) || cpf.Length != 11, "CPF inválido");
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Telefone é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco), "Endereço é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(fotoDocumento), "Documento de identificação é obrigatório");

            Nome = nome;
            Email = email;
            Senha = senha;
            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
            FotoDocumento = fotoDocumento;
        }

        public void VerificarEmail()
        {
            EmailVerificado = true;
        }
    }

    public enum TipoUsuario
    {
        Comum,
        Admin
    }
}
