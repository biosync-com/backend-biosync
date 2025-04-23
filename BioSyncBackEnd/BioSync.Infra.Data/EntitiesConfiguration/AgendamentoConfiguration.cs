using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class AgendamentoConfiguration
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Data);
            builder.Property(p => p.HoraInicioDisponivel);
            builder.Property(p => p.HoraInicioDisponivel);
            builder.Property(p => p.Status);
            builder.Property(p => p.PesoEstimadoKg);
            builder.Property(p => p.FotoResiduos);
            builder.Property(p => p.Observacoes);

            builder.HasOne(e => e.Usuario).WithMany(e => e.Agendamentos).HasForeignKey(e => e.UsuarioId);
           

        }
    }
}
