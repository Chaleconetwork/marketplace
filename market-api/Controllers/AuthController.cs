using AutoMapper;
using market_api.Dtos;
using market_api.Errors;
using market_api.Interfaces;
using market_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace market_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthInterface _authInterface;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthController(IAuthInterface authInterface, IMapper mapper, IConfiguration configuration)
        {
            _authInterface = authInterface;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>>? Register(UsuarioDto dto)
        {
            var response = await _authInterface.Register(dto);

            //return Ok(_mapper.Map<UsuarioDto, Usuario>(response));
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> IniciarSesion(UsuarioDto dto)
        {
            var response = await _authInterface?.IniciarSesion(dto);

            if (response == null)
            {
                return BadRequest(new CodeErrorResponse(404));
            }

            string token = CreateToken(_mapper.Map<UsuarioDto, Usuario>(response));

            return Ok(token);
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
