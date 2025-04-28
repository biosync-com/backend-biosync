using BioSync.Domain.Entities;
using BioSync.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class ColetorConfiguration : IEntityTypeConfiguration<Coletor>
    {
        public void Configure(EntityTypeBuilder<Coletor> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.FotoDocumento)
                .IsRequired();

            builder.Property(c => c.EmailVerificado)
                .IsRequired();

            builder.Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(100); 

            builder.Property(c => c.DataCadastro)
                .IsRequired();

            builder.HasOne(c => c.Endereco)
                .WithMany()
                .HasForeignKey(c => c.EnderecoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.AgendamentosAceitos)
                .WithOne(a => a.Coletor)
                .HasForeignKey(a => a.ColetorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(
            new Coletor("Guilherme Silva", "12345678901", "11987654321", "guilherme.silva@email.com",
            new Endereco("Rua Exemplo", "123", "Bairro Exemplo","Cidade Exemplo", Estado.SP, "01234567"), "fotoDocumentoUrl", "senhaSegura123", true)
            );
        }
    }
}
