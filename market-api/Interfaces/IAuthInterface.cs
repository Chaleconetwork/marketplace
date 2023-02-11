using market_api.Dtos;

namespace market_api.Interfaces
{
    public interface IAuthInterface
    {
        Task<UsuarioDto>? Register(UsuarioDto dto);
        Task<UsuarioDto>? IniciarSesion(UsuarioDto dto);
    }
}
