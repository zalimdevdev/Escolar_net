using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class AñoEscolar
{
    public int Id { get; set; }
    public string? NombreAño { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public string? Estado { get; set; }  // Estado del año escolar (activo, inactivo, etc.)

    // Relación con Periodos
    public List<Periodo>? Periodos { get; set; }

}
