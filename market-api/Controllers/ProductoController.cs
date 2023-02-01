using AutoMapper;
using market_api.Dtos;
using market_api.Errors;
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
        private readonly IMapper _mapper;

        public ProductoController(IGenericInterface<Producto> productoInterface, IMapper mapper)
        {
            _productoInterface = productoInterface;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var spec = new ProductoSpecification(id);
            var producto = await _productoInterface.GetByIdWithSpec(spec);

            if (producto == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            return Ok(_mapper.Map<Producto, ProductoDto>(producto));
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos()
        {
            var spec = new ProductoSpecification();
            var productos = await _productoInterface.GetAllWithSpec(spec);

            return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos));
        }
    }
}
