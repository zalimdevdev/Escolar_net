

using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class BoletinDeCalificacion
{
    public int Id { get; set; }
   
    public DateTime? Fecha { get; set; }  // Fecha de emisión del boletín


    // Relación con Estudiante
    public int? EstudianteId { get; set; }
    public Estudiante? Estudiante { get; set; }

    // Relación con Periodo
    public int? PeriodoId { get; set; }
    public Periodo? Periodo { get; set; }

    public DateTime FechaEmision { get; set; }
    public List<Nota>? Notas { get; set; } // Navigation property

}
