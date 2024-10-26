using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class Clase
{
    public int Id { get; set; }
    public string? Nombre { get; set; }  // Nombre de la clase (Ej: "Matemáticas", "Historia")
    public DateTime? HoraInicio { get; set; }  // Hora de inicio de la clase
    public DateTime? HoraFin { get; set; }  // Hora de fin de la clase

 // Relación con Profesor
    public int? ProfesorId { get; set; }
    public Profesor? Profesor { get; set; }

    // Relación con Aula
    public int? AulaId { get; set; }
    public Aula? Aula { get; set; }

    // Relación con Grado
    public int? GradoId { get; set; }
    public Grado? Grado { get; set; }

}
