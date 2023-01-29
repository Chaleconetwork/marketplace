using market_api.Data;
using market_api.Interfaces;
using market_api.Models;
using Microsoft.EntityFrameworkCore;

namespace market_api.Repositories
{
    public class ProductoRepository : IProductoInterface
    {
        private readonly Context _context;
        public ProductoRepository(Context context) 
        {
            _context = context;
        }

        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            var result = await _context.Productos
                                          .Include(p => p.Marcas)
                                          .Include(p => p.Categorias)
                                          .FirstOrDefaultAsync(p => p.ProductoId == id);

            return result;
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            var result = await _context.Productos
                                          .Include(p => p.Marcas)
                                          .Include(p => p.Categorias)
                                          .ToListAsync();

            return result;
        }
    }
}