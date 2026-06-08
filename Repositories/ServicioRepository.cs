using System.Collections.Concurrent;
using SistemaDeTurnosWeb.Models;

namespace SistemaDeTurnosWeb.Repositories;

public class ServicioRepository : IRepository<Servicio>
{
    private readonly ConcurrentDictionary<int, Servicio> _servicios = new();
    private int _nextId;

    public ServicioRepository()
    {
        // Seed data
        Add(new Servicio { Nombre = "Corte de cabello", DuracionEnMinutos = 30, Precio = 1200 });
        Add(new Servicio { Nombre = "Barba", DuracionEnMinutos = 15, Precio = 600 });
        Add(new Servicio { Nombre = "Corte + Barba", DuracionEnMinutos = 40, Precio = 1600 });
        Add(new Servicio { Nombre = "Corte degradado", DuracionEnMinutos = 45, Precio = 1500 });
    }

    public Servicio? GetById(int id)
        => _servicios.TryGetValue(id, out var servicio) ? servicio : null;

    public IEnumerable<Servicio> GetAll()
        => _servicios.Values;

    public Servicio Add(Servicio servicio)
    {
        servicio.Id = Interlocked.Increment(ref _nextId);
        _servicios[servicio.Id] = servicio;
        return servicio;
    }
}
