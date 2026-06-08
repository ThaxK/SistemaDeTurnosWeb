namespace SistemaDeTurnosWeb.Models;

public class Servicio
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int DuracionEnMinutos { get; set; }
    public decimal Precio { get; set; }
}
