using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Pages.Clientes;

public class CreateModel : PageModel
{
    private readonly IRepository<Cliente> _clientes;

    [BindProperty]
    public Cliente Cliente { get; set; } = new();

    public CreateModel(IRepository<Cliente> clientes)
    {
        _clientes = clientes;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _clientes.Add(Cliente);
        TempData["Mensaje"] = "Cliente registrado correctamente";
        return RedirectToPage("Index");
    }
}
