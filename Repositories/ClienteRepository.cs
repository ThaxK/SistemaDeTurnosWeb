using System.Collections.Concurrent;
using SistemaDeTurnosWeb.Models;

namespace SistemaDeTurnosWeb.Repositories;

public class ClienteRepository : IRepository<Cliente>
{
    private readonly ConcurrentDictionary<int, Cliente> _clientes = new();
    private int _nextId;

    public Cliente? GetById(int id)
        => _clientes.TryGetValue(id, out var cliente) ? cliente : null;

    public IEnumerable<Cliente> GetAll()
        => _clientes.Values;

    public Cliente Add(Cliente cliente)
    {
        cliente.Id = Interlocked.Increment(ref _nextId);
        _clientes[cliente.Id] = cliente;
        return cliente;
    }
}
