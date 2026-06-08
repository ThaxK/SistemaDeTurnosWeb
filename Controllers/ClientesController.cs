using Microsoft.AspNetCore.Mvc;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IRepository<Cliente> _clientes;

    public ClientesController(IRepository<Cliente> clientes)
    {
        _clientes = clientes;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cliente>> GetAll()
    {
        return Ok(_clientes.GetAll());
    }

    [HttpPost]
    public ActionResult<Cliente> Create(Cliente cliente)
    {
        var created = _clientes.Add(cliente);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }
}
