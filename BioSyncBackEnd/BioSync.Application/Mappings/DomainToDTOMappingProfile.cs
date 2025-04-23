using AutoMapper;
using BioSync.Application.DTOs;
using BioSync.Domain.Entities;

namespace BioSync.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Agendamento, AgendamentoDTO>().ReverseMap();
            CreateMap<CategoriaMaterial, CategoriaMaterialDTO>().ReverseMap();
            CreateMap<Coletor, ColetorDTO>().ReverseMap();
            CreateMap<Conteudos, ConteudosDTO>().ReverseMap();
            CreateMap<Material, MaterialDTO>().ReverseMap();
            CreateMap<Noticias, NoticiasDTO>().ReverseMap();
            CreateMap<PontoDescarte, PontoDescarteDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
