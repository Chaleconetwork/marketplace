using market_api.Models;

namespace market_api.Specifications
{
    public class ProductoSpecification: BaseSpecification<Producto>
    {
        public ProductoSpecification()
        {
            AddInclude(p => p.Categorias);
            AddInclude(p => p.Marcas);
        }

        public ProductoSpecification(int id): base(x => x.ProductoId == id)
        {
            AddInclude(p => p.Categorias);
            AddInclude(p => p.Marcas);
        }
    }
}
