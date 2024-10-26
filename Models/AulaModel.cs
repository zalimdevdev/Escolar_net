using System.ComponentModel.DataAnnotations.Schema;
//using Escolar_net.Migrations;
namespace Escolar_net.Models;

public class Aula
{
    public int Id { get; set; }
    public string? Nombre { get; set; }  // Nombre del aula (Ej: "Aula 1A")
    public string? Seccion { get; set; }  // Sección del aula (Ej: "A", "B", etc.)

    // Relación con Grado
    public int? GradoId { get; set; }
    public Grado? Grado { get; set; }



}
