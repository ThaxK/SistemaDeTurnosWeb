using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Pages.Servicios;

public class IndexModel : PageModel
{
    private readonly IRepository<Servicio> _servicios;

    public IEnumerable<Servicio> Servicios { get; set; } = [];

    public IndexModel(IRepository<Servicio> servicios)
    {
        _servicios = servicios;
    }

    public void OnGet()
    {
        Servicios = _servicios.GetAll();
    }
}
