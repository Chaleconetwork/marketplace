using AutoMapper;
using Azure;
using market_api.Data;
using market_api.Dtos;
using market_api.Interfaces;
using market_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace market_api.Repositories
{
    public class AuthRepository : IAuthInterface
    {
        private readonly Context _context;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthRepository(Context context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<UsuarioDto>? IniciarSesion(UsuarioDto dto)
        {
            var checkUser = await _context.Usuarios.Where(i => i.Nombre == dto.Nombre).AsNoTracking().FirstOrDefaultAsync();

            if (checkUser?.Nombre != dto.Nombre)
                return null;
            
            if (!BCrypt.Net.BCrypt.Verify(dto.Contrasena, checkUser?.Contrasena))
                return null;

            //string token = CreateToken(checkUser);

            return dto;
        }
         
        public async Task<UsuarioDto>? Register(UsuarioDto dto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Contrasena);
            dto.Contrasena = passwordHash;

            await _context.Usuarios.AddAsync(_mapper.Map<UsuarioDto, Usuario>(dto));
            await _context.SaveChangesAsync();

            return dto;
        }

        private string CreateToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
