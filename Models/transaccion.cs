namespace Proyecto3_pago.Models;

public class Transaccion
{
    public bool es_ingreso { get; set; }
    public double Monto { get; set; }
    public string? Glosa { get; set; }
    public DateTime Fecha { get; set; }
}
