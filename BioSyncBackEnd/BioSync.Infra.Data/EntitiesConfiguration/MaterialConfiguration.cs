using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
     
            builder.HasKey(m => m.Id);

        
            builder.Property(m => m.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.CategoriaMaterialId)
                .IsRequired();

         
            builder.HasOne(m => m.CategoriaMaterial)
                .WithMany()
                .HasForeignKey(m => m.CategoriaMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Material("Garrafa PET", 4) { Id = 1 }, 
                new Material("Bateria de celular", 2) { Id = 2 }, 
                new Material("Composto Orgânico", 3) { Id = 3 }, 
                new Material("Pote de vidro", 5) { Id = 4 } 
            );

        }
    }
}
