using BioSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BioSync.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Coletor> Coletores { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<CategoriaMaterial> CategoriasMateriais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Conteudos> Conteudos { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<PontoDescarte> PontosDescarte { get; set; }
        public DbSet<DiaFuncionamento> DiasFuncionamento { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
