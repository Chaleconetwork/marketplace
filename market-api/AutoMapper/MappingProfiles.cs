using AutoMapper;
using market_api.Dtos;
using market_api.Models;

namespace market_api.AutoMapper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>()
                                             .ForMember(p => p.CategoriaNombre, x => x.MapFrom(a => a.Categorias.Nombre))
                                             .ForMember(p => p.MarcaNombre, x => x.MapFrom(a => a.Marcas.Nombre));
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
