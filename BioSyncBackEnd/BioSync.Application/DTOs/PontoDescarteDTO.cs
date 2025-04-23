using System.ComponentModel.DataAnnotations;

namespace BioSync.Application.DTOs
{
    public class PontoDescarteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF ou CNPJ é obrigatório")]
        [MinLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        [MaxLength(11, ErrorMessage = "O CPF deve ter 11 caracteres")]
        public string Cpf { get; set; }

        [MinLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        [MaxLength(14, ErrorMessage = "O CNPJ deve ter 14 caracteres")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [MinLength(10, ErrorMessage = "O telefone deve ter no mínimo 10 caracteres")]
        [MaxLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail ou site é obrigatório")]
        public string EmailOuSite { get; set; }

        [Required(ErrorMessage = "O nome do responsável é obrigatório")]
        public string NomeResponsavel { get; set; }


        public PontoDescarteDTO(int id, string nome, string cpf, string cnpj, string telefone, string emailOuSite, string nomeResponsavel)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Cnpj = cnpj;
            Telefone = telefone;
            EmailOuSite = emailOuSite;
            NomeResponsavel = nomeResponsavel;
        
        }
    }
}
