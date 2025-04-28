using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Data).IsRequired();
            builder.Property(p => p.HoraInicioDisponivel).IsRequired();
            builder.Property(p => p.HoraInicioDisponivel).IsRequired();
            builder.Property(p => p.Status).HasMaxLength(50);
            builder.Property(p => p.PesoEstimadoKg);
            builder.Property(p => p.FotoResiduos).HasMaxLength(225);
            builder.Property(p => p.Observacoes).HasMaxLength(500);

            builder.HasOne(e => e.Usuario)
                .WithMany(e => e.Agendamentos)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Coletor)
                .WithMany(e => e.AgendamentosAceitos)
                .HasForeignKey(e => e.ColetorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Materiais)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
