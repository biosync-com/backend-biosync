using BioSync.Domain.Entities;
using BioSync.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

       
            builder.HasKey(u => u.Id);

      
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);  

            builder.Property(u => u.CPF)
                .IsRequired()
                .HasMaxLength(11); 

            builder.Property(u => u.Telefone)
                .IsRequired()
                .HasMaxLength(15); 

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);  

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.DataCadastro)
                .IsRequired(); 

            builder.Property(u => u.Tipo)
                .IsRequired(); 

            builder.Property(u => u.EmailVerificado)
                .IsRequired();  

            
            builder.HasMany(u => u.Agendamentos)
                .WithOne(a => a.Usuario)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade); 
            
            builder.HasOne(u => u.Endereco)
                .WithMany()
                .HasForeignKey(u => u.EnderecoId);  

           
            builder.HasData(
                new Usuario(
                    "João Silva",
                    "12345678901",
                    "11987654321",
                    "joao.silva@email.com",
                    new Endereco("Rua Central", "123", "Centro", "São Paulo", Estado.SP, "01001000"),
                    "fotoDocumentoUrl",
                    "senhaSegura123",
                    TipoUsuario.Usuario
                )
                {
                    Id = 1
                },
                new Usuario(
                    "Maria Oliveira",
                    "98765432100",
                    "11987654322",
                    "maria.oliveira@email.com",
                    new Endereco("Rua Exemplo", "456", "Bairro Exemplo", "São Paulo", Estado.SP, "02002000"),
                    "fotoDocumentoUrl",
                    "senhaSegura456",
                    TipoUsuario.Admin
                )
                {
                    Id = 2
                }
            );
        }
    }
}
