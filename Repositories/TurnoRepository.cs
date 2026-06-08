using System.Collections.Concurrent;
using SistemaDeTurnosWeb.Models;

namespace SistemaDeTurnosWeb.Repositories;

public class TurnoRepository : IRepository<Turno>
{
    private readonly ConcurrentDictionary<int, Turno> _turnos = new();
    private int _nextId;

    public Turno? GetById(int id)
        => _turnos.TryGetValue(id, out var turno) ? turno : null;

    public IEnumerable<Turno> GetAll()
        => _turnos.Values;

    public Turno Add(Turno turno)
    {
        turno.Id = Interlocked.Increment(ref _nextId);
        turno.Estado = EstadoTurno.Pendiente;
        _turnos[turno.Id] = turno;
        return turno;
    }

    public bool Cancel(int id)
    {
        if (!_turnos.TryGetValue(id, out var turno))
            return false;

        if (turno.Estado == EstadoTurno.Cancelado)
            return false;

        turno.Estado = EstadoTurno.Cancelado;
        return true;
    }

    public bool Realizar(int id)
    {
        if (!_turnos.TryGetValue(id, out var turno))
            return false;

        if (turno.Estado != EstadoTurno.Pendiente)
            return false;

        turno.Estado = EstadoTurno.Realizado;
        return true;
    }
}
