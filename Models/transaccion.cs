public enum TipoTransaccion { Ingreso, Retiro }

public class Transaccion
{
    public int Id { get; set; }
    public TipoTransaccion Tipo { get; set; }
    public double Monto { get; set; }
    public string? Descripcion { get; set; }
    public DateTime Fecha { get; set; }
}
