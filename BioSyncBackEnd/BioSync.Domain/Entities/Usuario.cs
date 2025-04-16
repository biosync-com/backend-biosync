﻿using BioSync.Domain.Validation;

namespace BioSync.Domain.Entities
{
    public class Usuario : Pessoa
    {
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public ICollection<Agendamento> Agendamentos { get; private set; }

        public Usuario(string nome, string cpf, string telefone, string email, Endereco endereco, string fotoDocumento, string senha)
            : base(nome, cpf, telefone, email, endereco, fotoDocumento)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(senha) || senha.Length < 8, "Senha inválida, mínimo 8 caracteres.");
            Senha = senha;
            DataCadastro = DateTime.Now;
            Agendamentos = new List<Agendamento>();
        }
    }
}
