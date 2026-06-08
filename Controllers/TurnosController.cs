using Microsoft.AspNetCore.Mvc;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TurnosController : ControllerBase
{
    private readonly IRepository<Turno> _turnos;
    private readonly IRepository<Servicio> _servicios;
    private readonly IRepository<Cliente> _clientes;

    public TurnosController(
        IRepository<Turno> turnos,
        IRepository<Servicio> servicios,
        IRepository<Cliente> clientes)
    {
        _turnos = turnos;
        _servicios = servicios;
        _clientes = clientes;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Turno>> GetAll()
    {
        return Ok(_turnos.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Turno> GetById(int id)
    {
        var turno = _turnos.GetById(id);
        if (turno is null)
            return NotFound();

        return Ok(turno);
    }

    [HttpPost]
    public ActionResult<Turno> Create(Turno turno)
    {
        // Validar que el servicio existe
        var servicio = _servicios.GetById(turno.ServicioId);
        if (servicio is null)
            return BadRequest($"No existe un servicio con id {turno.ServicioId}");

        // Validar que el cliente existe
        var cliente = _clientes.GetById(turno.ClienteId);
        if (cliente is null)
            return BadRequest($"No existe un cliente con id {turno.ClienteId}");

        // Poblar nombres de navegación
        turno.ServicioNombre = servicio.Nombre;
        turno.ClienteNombre = cliente.Nombre;

        var created = _turnos.Add(turno);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public ActionResult Cancel(int id)
    {
        var turno = _turnos.GetById(id);
        if (turno is null)
            return NotFound();

        if (turno.Estado == EstadoTurno.Cancelado)
            return BadRequest("El turno ya está cancelado");

        _turnos.Cancel(id);
        return Ok(new { message = "Turno cancelado correctamente" });
    }
}
