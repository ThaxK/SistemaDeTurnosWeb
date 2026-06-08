namespace SistemaDeTurnosWeb.Models;

public enum EstadoTurno
{
    Pendiente,
    Confirmado,
    Realizado,
    Cancelado
}

public class Turno
{
    public int Id { get; set; }
    public int ServicioId { get; set; }
    public int ClienteId { get; set; }
    public DateTime FechaHora { get; set; }
    public EstadoTurno Estado { get; set; } = EstadoTurno.Pendiente;

    // Propiedades de navegación (solo lectura desde respuesta API)
    public string? ServicioNombre { get; set; }
    public string? ClienteNombre { get; set; }
}
