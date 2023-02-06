namespace market_api.Dtos
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Token { get; set; }
        public int Rol { get; set; }
    }
}
