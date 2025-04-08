using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Endereco
    {
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }

        public Endereco(string rua, string numero, string bairro, string cidade, string estado, string cep)
        {
            ValidateDomain(rua, numero, bairro, cidade, estado, cep);
        }

        private void ValidateDomain(string rua, string numero, string bairro, string cidade, string estado, string cep)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(rua), "Rua é obrigatória");
            DomainExceptionValidation.When(string.IsNullOrEmpty(numero), "Número é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(bairro), "Bairro é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cidade), "Cidade é obrigatória");
            DomainExceptionValidation.When(string.IsNullOrEmpty(estado), "Estado é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cep), "CEP é obrigatório");

            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }
    }
}
