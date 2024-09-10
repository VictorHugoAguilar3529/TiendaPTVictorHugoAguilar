using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TiandaPTCrud.BLL.Service;
using TiandaPTCrud.DAL.DataContext;
using TiandaPTCrud.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Añade servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddScoped<IClienteService, ClienteService>(); // Registro del servicio
builder.Services.AddScoped<ITiendaService, TiendaService>(); // Registro del servicio
builder.Services.AddScoped<IArtículoService, ArtículoService>(); // Registro del servicio
builder.Services.AddScoped<IClienteArtículoService, ClienteArtículoService>(); // Registro del servicio
builder.Services.AddScoped<IArtículoTiendaService, ArtículoTiendaService>(); // Registro del servicio
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddDbContext<tiendabdContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configura el pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseRouting();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
