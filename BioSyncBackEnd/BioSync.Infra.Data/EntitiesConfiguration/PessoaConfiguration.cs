using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class PessoaConfiguration
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome);
            builder.Property(p => p.CPF);
            builder.Property(p => p.Telefone);
            builder.Property(p => p.Email);

        }
    }
}
