using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BioSync.Infra.Data.EntitiesConfiguration
{
    public class NoticiasConfiguration : IEntityTypeConfiguration<Noticias>
    {
        public void Configure(EntityTypeBuilder<Noticias> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(n => n.Conteudo)
                .IsRequired();
                

            builder.Property(n => n.ImagemUrl)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(n => n.Autor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(n => n.DataPublicacao)
                .IsRequired();

           
            builder.HasData(
                new Noticias(
                    "Campanha de Reciclagem nas Escolas",
                    "Estamos lançando uma nova campanha para incentivar a reciclagem nas escolas da região. " +
                    "Participe e ajude a preservar o meio ambiente!",
                    "https://example.com/imagem-campanha.jpg",
                    "Admin"
                )
                {
                    Id = 1,
                    DataPublicacao = new DateTime(2025, 4, 25) 
                }
            );
        }
    }
}
