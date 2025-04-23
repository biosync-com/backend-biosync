using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class PontoDescarte : Entity
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string EmailOuSite { get; set; }
        public string NomeResponsavel { get; set; }

        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public ICollection<DiaFuncionamento> DiasFuncionamento { get; set; }

        public PontoDescarte(
            string nome, string cpf, string cnpj, string telefone,
            string emailOuSite, string nomeResponsavel, Endereco endereco)
        {
            ValidateDomain(nome, cpf, cnpj, telefone, emailOuSite, nomeResponsavel, endereco);
            DiasFuncionamento = new List<DiaFuncionamento>();
        }

        private void ValidateDomain(
            string nome, string cpf, string cnpj, string telefone,
            string emailOuSite, string nomeResponsavel, Endereco endereco)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nome), "Nome é obrigatório");
            DomainExceptionValidation.When(nome.Length < 3, "Nome muito curto, mínimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf) && string.IsNullOrEmpty(cnpj),
                "É necessário fornecer CPF ou CNPJ");

            if (!string.IsNullOrEmpty(cpf))
                DomainExceptionValidation.When(cpf.Length != 11, "CPF inválido");

            if (!string.IsNullOrEmpty(cnpj))
                DomainExceptionValidation.When(cnpj.Length != 14, "CNPJ inválido");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(telefone), "Telefone é obrigatório");
            DomainExceptionValidation.When(telefone.Length < 10 || telefone.Length > 15,
                "Telefone inválido");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(emailOuSite),
                "Contato por e-mail ou site é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(nomeResponsavel),
                "Nome do responsável é obrigatório");

            DomainExceptionValidation.When(endereco == null, "Endereço é obrigatório");

            Nome = nome;
            Cpf = cpf;
            Cnpj = cnpj;
            Telefone = telefone;
            EmailOuSite = emailOuSite;
            NomeResponsavel = nomeResponsavel;
            Endereco = endereco;
            EnderecoId = endereco.Id;
        }
    }
}
