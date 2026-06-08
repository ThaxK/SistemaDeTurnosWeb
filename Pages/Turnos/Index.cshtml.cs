using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Pages.Turnos;

public class IndexModel : PageModel
{
    private readonly IRepository<Turno> _turnos;

    public IEnumerable<Turno> Turnos { get; set; } = [];
    public string? Mensaje { get; set; }

    public IndexModel(IRepository<Turno> turnos)
    {
        _turnos = turnos;
    }

    public void OnGet()
    {
        Turnos = _turnos.GetAll().OrderBy(t => t.FechaHora);
        Mensaje = TempData["Mensaje"] as string;
    }

    public IActionResult OnPostCancelar(int id)
    {
        var turno = _turnos.GetById(id);
        if (turno is null)
            return NotFound();

        if (turno.Estado == EstadoTurno.Cancelado)
        {
            TempData["Mensaje"] = "El turno ya está cancelado";
            return RedirectToPage("Index");
        }

        _turnos.Cancel(id);
        TempData["Mensaje"] = "Turno cancelado correctamente";
        return RedirectToPage("Index");
    }

    public IActionResult OnPostRealizar(int id)
    {
        var turno = _turnos.GetById(id);
        if (turno is null)
            return NotFound();

        if (turno.Estado != EstadoTurno.Pendiente)
        {
            TempData["Mensaje"] = "Solo se pueden marcar como realizados los turnos pendientes";
            return RedirectToPage("Index");
        }

        _turnos.Realizar(id);
        TempData["Mensaje"] = "Turno marcado como realizado";
        return RedirectToPage("Index");
    }
}
