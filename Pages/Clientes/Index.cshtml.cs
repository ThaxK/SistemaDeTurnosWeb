using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Pages.Clientes;

public class IndexModel : PageModel
{
    private readonly IRepository<Cliente> _clientes;

    public IEnumerable<Cliente> Clientes { get; set; } = [];

    public IndexModel(IRepository<Cliente> clientes)
    {
        _clientes = clientes;
    }

    public void OnGet()
    {
        Clientes = _clientes.GetAll();
    }
}
