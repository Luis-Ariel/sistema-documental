using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GestionDocumental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using GestionDocumental.Infrastructure.Services;
using GestionDocumental.API.Middleware; // Importar el middleware

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "API de Gestión Documental", 
        Version = "v1",
        Description = "API para gestionar documentos en la Ilustre Municipalidad de Valparaíso."
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<DocumentosService>();

var app = builder.Build();

// Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Gestión Documental v1"));
}

// *** Agregar el middleware de excepciones antes de manejar las rutas ***
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();