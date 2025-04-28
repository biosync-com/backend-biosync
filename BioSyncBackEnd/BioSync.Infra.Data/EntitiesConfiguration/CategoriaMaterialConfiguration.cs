using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class CategoriaMaterialConfiguration : IEntityTypeConfiguration<CategoriaMaterial>
    {
        public void Configure(EntityTypeBuilder<CategoriaMaterial> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasMany(c => c.Materiais)
                   .WithOne(m => m.CategoriaMaterial)
                   .HasForeignKey(m => m.CategoriaMaterialId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new CategoriaMaterial(1,"Eletrônicos", "Dispositivos e equipamentos eletrônicos, como TVs, celulares e computadores."),
                new CategoriaMaterial(2,"Baterias", "Baterias usadas em dispositivos, como baterias de carros e aparelhos portáteis."),
                new CategoriaMaterial(3,"Resíduos Orgânicos", "Resíduos biodegradáveis como restos de alimentos, folhas e outros materiais naturais."),
                new CategoriaMaterial(4,"Plástico", "Resíduos plásticos de embalagens, garrafas PET e outros itens recicláveis."),
                new CategoriaMaterial(5,"Vidro", "Resíduos de vidro como garrafas, frascos e outros itens feitos de vidro."),
                new CategoriaMaterial(6, "Metal", "Materiais metálicos como alumínio, ferro e aço.")
            );
        }
    }
}
