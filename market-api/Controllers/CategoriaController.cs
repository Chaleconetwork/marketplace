using market_api.Interfaces;
using market_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace market_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IGenericInterface<Categoria> _categoriaInterface;

        public CategoriaController(IGenericInterface<Categoria> categoriaInterface)
        {
            _categoriaInterface = categoriaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> GetCategorias()
        {
            return Ok(await _categoriaInterface.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> GetCategoria(int id)
        {
            return Ok(await _categoriaInterface.GetByIdAsync(id));
        }
    }
}
