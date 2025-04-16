using BioSync.Application.Interfaces;
using BioSync.Application.Mappings;
using BioSync.Application.Services;
using BioSync.Domain.Interfaces;
using BioSync.Infra.Data.Context;
using BioSync.Infra.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BioSync.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastrutureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


            services.AddScoped<ICategoriaMaterialRepository, CategoriaMaterialRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IColetorRepository, ColetorRepository>();
            services.AddScoped<IConteudosRepository, ConteudosRepository>();
            services.AddScoped<INoticiasRepository, NoticiasRepository>();
            services.AddScoped<IPontoDescarteRepository, PontoDescarteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();


            services.AddScoped<ICategoriaMaterialService, CategoriaMaterialService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IColetorService, ColetorService>();
            services.AddScoped<IConteudosService, ConteudosService>();
            services.AddScoped<INoticiasService, NoticiasService>();
            services.AddScoped<IPontoDescarteService, PontoDescarteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAgendamentoService, AgendamentoService>();

            services.AddAutoMapper(new[] { typeof(DomainToDTOMappingProfile).Assembly });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionAPI).Assembly));

            return services;
        }
    }
}
