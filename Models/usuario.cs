namespace Proyecto3_pago.Models;
public class Usuario
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public double Ingresos { get; set; }
    public double Egresos { get; set; }
}
