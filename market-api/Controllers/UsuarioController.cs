using AutoMapper;
using market_api.Dtos;
using market_api.Interfaces;
using market_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace market_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IGenericInterface<Usuario> _genericInterface;

        public UsuarioController(IGenericInterface<Usuario> genericInterface)
        {
            _genericInterface = genericInterface;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDto>>> GetUsuarios()
        {
            var response = await _genericInterface.GetAllAsync();
            return Ok(response);
        }
    }
}
