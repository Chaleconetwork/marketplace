using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace market_api.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Contrasena { get; set; }

        public int? RolUsuarioId { get; set; }
        public RolUsuario? RolUsuarios { get; set; }
    }
}
