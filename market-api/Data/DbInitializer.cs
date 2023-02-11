using market_api.Models;
using Microsoft.EntityFrameworkCore;

namespace market_api.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(Context context)
        {
            if (true)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();

                await Seed(context);
            }
        }

        private static async Task Seed(Context context)
        {
            if (!await context.RolUsuarios.AnyAsync())
            {
                await context.RolUsuarios.AddAsync(new RolUsuario() { Nombre = "administrador" });
            }

            if (!await context.Usuarios.AnyAsync())
            {
                await context.Usuarios.AddAsync(new Usuario() { Nombre = "chaleco", Contrasena = "1234", RolUsuarioId = 1 });
                await context.Usuarios.AddAsync(new Usuario() { Nombre = "junior", Contrasena = "1234", RolUsuarioId = 1 });
            }

            if (!await context.Marcas.AnyAsync())
            {
                await context.Marcas.AddAsync(new Marca() { Nombre = "test" });
                await context.Marcas.AddAsync(new Marca() { Nombre = "Iphone" });
            }

            if (!await context.Categorias.AnyAsync())
            {
                await context.Categorias.AddAsync(new Categoria() { Nombre = "Android" });
                await context.Categorias.AddAsync(new Categoria() { Nombre = "Ios" });
            }

            if (!await context.Productos.AnyAsync())
            {
                await context.Productos.AddAsync(new Producto() { Nombre = "Celular", Descripcion = "Khaaa", Stock = 20, Precio = 400000, Imagen = "", MarcaId = 1, CategoriaId = 1 });
                await context.Productos.AddAsync(new Producto() { Nombre = "Celular", Descripcion = "Khaaa", Stock = 20, Precio = 600000, Imagen = "", MarcaId = 2, CategoriaId = 2 });
                await context.Productos.AddAsync(new Producto() { Nombre = "Celular", Descripcion = "Khaaa", Stock = 20, Precio = 500000, Imagen = "", MarcaId = 1, CategoriaId = 1 });
            }

            await context.SaveChangesAsync();
        }
    }
}
