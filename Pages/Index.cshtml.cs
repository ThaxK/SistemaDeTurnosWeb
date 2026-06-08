using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Pages;

public class IndexModel : PageModel
{
    private readonly IRepository<Servicio> _servicios;
    private readonly IRepository<Cliente> _clientes;
    private readonly IRepository<Turno> _turnos;

    public int TotalServicios { get; set; }
    public int TotalClientes { get; set; }
    public int TotalTurnos { get; set; }
    public int TurnosHoy { get; set; }
    public int TurnosPendientes { get; set; }
    public IEnumerable<Turno> ProximosTurnos { get; set; } = [];

    public IndexModel(
        IRepository<Servicio> servicios,
        IRepository<Cliente> clientes,
        IRepository<Turno> turnos)
    {
        _servicios = servicios;
        _clientes = clientes;
        _turnos = turnos;
    }

    public void OnGet()
    {
        TotalServicios = _servicios.GetAll().Count();
        TotalClientes = _clientes.GetAll().Count();
        TotalTurnos = _turnos.GetAll().Count();
        TurnosPendientes = _turnos.GetAll().Count(t => t.Estado == EstadoTurno.Pendiente);
        TurnosHoy = _turnos.GetAll().Count(t => t.FechaHora.Date == DateTime.Today);
        ProximosTurnos = _turnos.GetAll()
            .Where(t => t.Estado != EstadoTurno.Cancelado)
            .OrderBy(t => t.FechaHora)
            .Take(5);
    }
}
