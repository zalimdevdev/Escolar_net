using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class Materia
{
    public int Id { get; set; }
    public string? Nombre { get; set; }  // Nombre de la materia (Ej: "Matemáticas", "Historia")

   // Relación con Clases
    public List<Clase>? Clases { get; set; }

}
