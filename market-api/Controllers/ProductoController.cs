using market_api.Interfaces;
using market_api.Models;
using market_api.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace market_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericInterface<Producto> _productoInterface;

        public ProductoController(IGenericInterface<Producto> productoInterface)
        {
            _productoInterface = productoInterface;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var spec = new ProductoSpecification(id);
            var producto = await _productoInterface.GetByIdWithSpec(spec);
            return Ok(producto);
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoSpecification();
            var productos = await _productoInterface.GetAllWithSpec(spec);
            return Ok(productos);
        }
    }
}
