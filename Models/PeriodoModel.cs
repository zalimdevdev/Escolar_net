using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class Periodo
{
    public int Id { get; set; }
    public string? Nombre { get; set; }  // Nombre del periodo (Ej: "Primer Periodo", "Segundo Periodo")
    public DateTime? FechaInicio { get; set; }  // Fecha de inicio del periodo
    public DateTime? FechaFin { get; set; }  // Fecha de fin del periodo

    // Relación con AñoEscolar
    public int? AñoEscolarId { get; set; }
    public AñoEscolar? AñoEscolar { get; set; }

    // Relación con Boletines
    public List<BoletinDeCalificacion>? Boletines { get; set; }

}
