using System.ComponentModel.DataAnnotations;

namespace market_api.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string? Nombre { get; set; }
    }
}
