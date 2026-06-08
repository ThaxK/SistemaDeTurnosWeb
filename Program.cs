using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddOpenApi();

// Repositorios en memoria (Singleton: viven mientras la app esté corriendo)
builder.Services.AddSingleton<IRepository<Cliente>, ClienteRepository>();
builder.Services.AddSingleton<IRepository<Servicio>, ServicioRepository>();
builder.Services.AddSingleton<IRepository<Turno>, TurnoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.Run();
