using SQLite;

namespace Proyecto3_pago.DataBases.Models;

public class Transaction
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public double Amount { get; set; }
    public bool IsEarning { get; set; }
    public string Detail { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public int UserId { get; set; }
}
