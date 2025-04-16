using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Coletor : Pessoa
    {
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public ICollection<Agendamento> AgendamentosAceitos { get; private set; }
        public ICollection<Material> MateriaisColetados { get; private set; }

        public Coletor(string nome, string cpf, string telefone, string email, Endereco endereco, string fotoDocumento, string senha)
            : base(nome, cpf, telefone, email, endereco, fotoDocumento)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(senha) || senha.Length < 8,
                "Senha muito curta, mínimo 8 caracteres");

            Senha = senha;
            DataCadastro = DateTime.Now;
            AgendamentosAceitos = new List<Agendamento>();
            MateriaisColetados = new List<Material>();
        }

        public void AceitarAgendamento(Agendamento agendamento)
        {
            DomainExceptionValidation.When(agendamento == null, "Agendamento inválido.");
            AgendamentosAceitos.Add(agendamento);
        }

        public void AdicionarMaterial(Material material)
        {
            DomainExceptionValidation.When(material == null, "Material inválido.");
            MateriaisColetados.Add(material);
        }
    }
}
