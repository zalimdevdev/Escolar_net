using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class Matricula
{
    public int Id { get; set; }
    public DateTime? FechaMatricula { get; set; }  // Fecha de matrícula

 // Relación con Estudiante
    public int? EstudianteId { get; set; }
    public string? EstudianteMatricula { get; set; }

    public string? GradoMatricula { get; set; }

}
