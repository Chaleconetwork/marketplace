using System.ComponentModel.DataAnnotations;

namespace market_api.Models
{
    public class Marca
    {
        [Key]
        public int MarcaId { get; set; }
        public string? Nombre { get; set;}
    }
}
