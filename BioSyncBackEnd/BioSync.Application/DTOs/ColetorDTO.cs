using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class ColetorDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do coletor é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF do coletor é obrigatório")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres", MinimumLength = 11)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O telefone do coletor é obrigatório")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail do coletor é obrigatório")]
        [EmailAddress(ErrorMessage = "O e-mail fornecido é inválido")]
        [MaxLength(250, ErrorMessage = "O e-mail não pode ter mais de 250 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O endereço do coletor é obrigatório")]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "A senha do coletor é obrigatória")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A data de cadastro é obrigatória")]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O status do coletor é obrigatório")]
        [MaxLength(20, ErrorMessage = "O status não pode ter mais que 20 caracteres")]
        public string Status { get; set; }

        public List<AgendamentoDTO> AgendamentosAceitos { get; set; }
        public List<MaterialDTO> MateriaisColetados { get; set; }

        public ColetorDTO(int id, string nome, string cpf, string telefone, string email, int enderecoId,
                          string senha, DateTime dataCadastro, string status)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            EnderecoId = enderecoId;
            Senha = senha;
            DataCadastro = dataCadastro;
            Status = status;
            AgendamentosAceitos = new List<AgendamentoDTO>();
            MateriaisColetados = new List<MaterialDTO>();
        }
    }
}
