using System.ComponentModel.DataAnnotations;

namespace market_api.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Stock { get; set; }
        public decimal Precio { get; set; }
        public string? Imagen { get; set; }

        public int? MarcaId { get; set; }
        public Marca? Marcas { get; set; }

        public int? CategoriaId { get; set; }
        public Categoria? Categorias { get; set; }
    }
}
