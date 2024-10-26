using System.ComponentModel.DataAnnotations.Schema;
namespace Escolar_net.Models;

public class Factura
{
    public int Id { get; set; }

    public string? MotivoDePago { get; set; }
    public DateTime? FechaEmision { get; set; }  // Fecha de emisión de la factura
    public decimal? MontoTotal { get; set; }  // Monto total a pagar
    public string? Estado { get; set; }  // Estado de la factura (Pagada/Pendiente)
}
