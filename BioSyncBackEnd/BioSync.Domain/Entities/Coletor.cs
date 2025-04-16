namespace BioSync.Domain.Entities
{
    public class Coletor : Pessoa
    {
        public DateTime DataCadastro { get; private set; }

        public ICollection<Agendamento> AgendamentosAceitos { get; private set; }
        public ICollection<Material> MateriaisColetados { get; private set; }

        public Coletor(string nome, string cpf, string telefone, string email, Endereco endereco, string fotoDocumento)
            : base(nome, cpf, telefone, email, endereco, fotoDocumento)
        {
            DataCadastro = DateTime.Now;
            AgendamentosAceitos = new List<Agendamento>();
            MateriaisColetados = new List<Material>();
        }
    }
}
