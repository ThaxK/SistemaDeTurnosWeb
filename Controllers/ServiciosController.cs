using Microsoft.AspNetCore.Mvc;
using SistemaDeTurnosWeb.Models;
using SistemaDeTurnosWeb.Repositories;

namespace SistemaDeTurnosWeb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiciosController : ControllerBase
{
    private readonly IRepository<Servicio> _servicios;

    public ServiciosController(IRepository<Servicio> servicios)
    {
        _servicios = servicios;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Servicio>> GetAll()
    {
        return Ok(_servicios.GetAll());
    }

    [HttpPost]
    public ActionResult<Servicio> Create(Servicio servicio)
    {
        var created = _servicios.Add(servicio);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }
}
