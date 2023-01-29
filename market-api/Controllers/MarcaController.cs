using market_api.Interfaces;
using market_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace market_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IGenericInterface<Marca> _marcaInterface;

        public MarcaController(IGenericInterface<Marca> marcaInterface)
        {
            _marcaInterface = marcaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> GetMarcas()
        {
            return Ok(await _marcaInterface.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> GetMarca(int id)
        {
            return Ok(await _marcaInterface.GetByIdAsync(id));
        }
    }
}
