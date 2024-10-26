


using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class Nota
{
    public int Id { get; set; }
public int? BoletinDeCalificacionId { get; set; } // Foreign key to BoletinDeCalificacion
    public int? MateriaId { get; set; } // Foreign key to Materia
    public decimal? Valor { get; set; } // Calificación

    // Navigation properties
        public virtual BoletinDeCalificacion? BoletinDeCalificacion { get; set; }
        public virtual Materia? Materia { get; set; }
}
