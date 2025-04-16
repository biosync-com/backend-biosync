using System;
using BioSync.Domain.Enums;

namespace BioSync.Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public int EnderecoId { get; set; }

        public string FotoDocumento { get; set; }

        public bool EmailVerificado { get; set; }

        public DateTime DataCadastro { get; set; }

        public TipoUsuario Tipo { get; set; }

        public UsuarioDTO(int id, string nome, string cpf, string telefone, string email, int enderecoId, string fotoDocumento, bool emailVerificado, DateTime dataCadastro, TipoUsuario tipo)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            EnderecoId = enderecoId;
            FotoDocumento = fotoDocumento;
            EmailVerificado = emailVerificado;
            DataCadastro = dataCadastro;
            Tipo = tipo;
        }
    }
}
