using SQLite;

namespace Proyecto3_pago.DataBases.Models;

[SQLite.Table("transaction")]
public class Transaction
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public double Amount { get; set; }
    public bool IsEarning { get; set; }
    public string Detail { get; set; }
    public DateTime Date { get; set; }

    // SQLite-net no soporta claves foráneas con atributos.
    // Puedes usar convenciones de nombres (UserId) y manejar relaciones manualmente.
    public int UserId { get; set; }
}
