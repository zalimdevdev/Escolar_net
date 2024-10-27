using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class Estudiante
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public DateTime? FechaNacimiento { get; set; }  // Fecha de nacimiento del estudiante
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }

    

    // Relación con Tutor
   // public int? TutorId { get; set; }
   // public Tutor? Tutor { get; set; }

    // Relación con Matriculas


    // Relación con Boletines
    public List<BoletinDeCalificacion>? Boletines { get; set; }


}

