using System.ComponentModel.DataAnnotations;

namespace market_api.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public int Rol { get; set; }
    }
}
