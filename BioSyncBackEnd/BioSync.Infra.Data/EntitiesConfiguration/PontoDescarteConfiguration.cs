using BioSync.Domain.Entities;
using BioSync.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class PontoDescarteConfiguration : IEntityTypeConfiguration<PontoDescarte>
    {
        public void Configure(EntityTypeBuilder<PontoDescarte> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Cpf)
                .HasMaxLength(11);

            builder.Property(p => p.Cnpj)
                .HasMaxLength(14);

            builder.Property(p => p.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.EmailOuSite)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.NomeResponsavel)
                .IsRequired()
                .HasMaxLength(100);


            builder.HasOne(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(p => p.DiasFuncionamento)
                .WithOne()
                .HasForeignKey(d => d.PontoDescarteId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
     new PontoDescarte(
         "Ponto de Reciclagem Centro", "12345678901", "12345678000199", "11987654321",
         "ponto.centro@email.com", "Guilherme silva", new Endereco("Rua Central", "123", "Centro", "São Paulo", Estado.SP, "01001000")
     )
     {
         Id = 1,
         DiasFuncionamento = new List<DiaFuncionamento>
         {
            new DiaFuncionamento
            {
                Dia = DiaSemana.Segunda,
                HoraInicio = new TimeSpan(8, 0, 0),
                HoraFim = new TimeSpan(18, 0, 0)
            },
            new DiaFuncionamento
            {
                Dia = DiaSemana.Quarta,
                HoraInicio = new TimeSpan(8, 0, 0),
                HoraFim = new TimeSpan(18, 0, 0)
            }
         }
     }
 );

        }
    }
}
