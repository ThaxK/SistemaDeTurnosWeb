using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Pages.Turnos;

public class CreateModel : PageModel
{
    private readonly IRepository<Turno> _turnos;
    private readonly IRepository<Servicio> _servicios;
    private readonly IRepository<Cliente> _clientes;

    [BindProperty]
    public Turno Turno { get; set; } = new();

    public List<SelectListItem> ServiciosList { get; set; } = [];
    public List<SelectListItem> ClientesList { get; set; } = [];
    public string? Error { get; set; }

    public CreateModel(
        IRepository<Turno> turnos,
        IRepository<Servicio> servicios,
        IRepository<Cliente> clientes)
    {
        _turnos = turnos;
        _servicios = servicios;
        _clientes = clientes;
    }

    public void OnGet()
    {
        CargarListas();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            CargarListas();
            return Page();
        }

        // Validar que el servicio existe
        var servicio = _servicios.GetById(Turno.ServicioId);
        if (servicio is null)
        {
            Error = "El servicio seleccionado no existe";
            CargarListas();
            return Page();
        }

        // Validar que el cliente existe
        var cliente = _clientes.GetById(Turno.ClienteId);
        if (cliente is null)
        {
            Error = "El cliente seleccionado no existe";
            CargarListas();
            return Page();
        }

        Turno.ServicioNombre = servicio.Nombre;
        Turno.ClienteNombre = cliente.Nombre;

        _turnos.Add(Turno);
        TempData["Mensaje"] = "Turno creado correctamente";
        return RedirectToPage("Index");
    }

    private void CargarListas()
    {
        ServiciosList = _servicios.GetAll()
            .Select(s => new SelectListItem(s.Nombre, s.Id.ToString()))
            .ToList();

        ClientesList = _clientes.GetAll()
            .Select(c => new SelectListItem(c.Nombre, c.Id.ToString()))
            .ToList();
    }
}
