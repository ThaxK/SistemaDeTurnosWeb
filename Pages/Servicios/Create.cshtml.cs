using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Pages.Servicios;

public class CreateModel : PageModel
{
    private readonly IRepository<Servicio> _servicios;

    [BindProperty]
    public Servicio Servicio { get; set; } = new();

    public CreateModel(IRepository<Servicio> servicios)
    {
        _servicios = servicios;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _servicios.Add(Servicio);
        TempData["Mensaje"] = "Servicio creado correctamente";
        return RedirectToPage("Index");
    }
}
