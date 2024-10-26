using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class Profesor
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }

    // Relación con Clases
    public List<Clase>? Clases { get; set; }
}
