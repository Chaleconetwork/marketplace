using market_api.AutoMapper;
using market_api.Data;
using market_api.Interfaces;
using market_api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolices", api =>
    {
        api.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Conexión base de datos
string? con = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(con));

// Interfaces
builder.Services.AddScoped<IProductoInterface, ProductoRepository>();
builder.Services.AddScoped(typeof(IGenericInterface<>), (typeof(GenericRepository<>)));

// Inyeccion de AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

// Inicializar base de datos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<Context>();

        await DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        string erroBD = ex.Message.ToString();
    }
}

if (app.Environment.IsDevelopment())
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseCors("NewPolices");

app.UseAuthorization();

app.MapControllers();

app.Run();