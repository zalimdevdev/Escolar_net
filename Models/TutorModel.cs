using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class Tutor
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }

    public List<Estudiante>? Estudiantes { get; set; }

}
