using market_api.Models;

namespace market_api.Dtos
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Stock { get; set; }
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }
        public string? MarcaNombre { get; set; }
        public string? CategoriaNombre { get; set; }        
    }
}