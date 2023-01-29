using market_api.Models;

namespace market_api.Interfaces
{
    public interface IProductoInterface
    {
        Task<Producto?> GetProductoByIdAsync(int id);
        Task<IReadOnlyList<Producto>>? GetProductosAsync();
    }
}
