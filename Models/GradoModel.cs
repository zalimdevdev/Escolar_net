using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;


public class Grado
{
    public int Id { get; set; }
    public string? Nombre { get; set; }  // Nombre del grado (Ej: "1er Grado", "2do Grado")
    public string? Seccion { get; set; }  // Sección del grado (Ej: "A", "B")

    // Relación con Aulas
    public List<Aula>? Aulas { get; set; }

    // Relación con Clases
    public List<Clase>? Clases { get; set; }

}
