using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class ConteudosConfiguration : IEntityTypeConfiguration<Conteudos>
    {
        public void Configure(EntityTypeBuilder<Conteudos> builder)
        {
          
            builder.HasKey(c => c.Id);

         
            builder.Property(c => c.Titulo)
                .HasMaxLength(100)
                .IsRequired(); 

            builder.Property(c => c.Texto)
                .IsRequired();  

            builder.Property(c => c.ImagemUrl)
                .HasMaxLength(250)
                .IsRequired();  

            builder.Property(c => c.VideoUrl)
                .HasMaxLength(250);  

            builder.Property(c => c.DataPublicacao)
                .IsRequired();  

            builder.HasData(
                new Conteudos
                (
                    "Exemplo de Conteúdo",
                    "Este é um exemplo de conteúdo,um exemplo de conteúdo,um exemplo de conteúdo",
                    "https://example.com/imagem.jpg",
                    "https://example.com/video.mp4"
                )
                {
                    DataPublicacao = DateTime.Now 
                }
            );
        }
    }
}
