using SQLite;

namespace Proyecto3_pago.DataBases.Models;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Earnings { get; set; }
    public double Spending { get; set; }

    [Ignore]
    public double Balance => Earnings - Spending;
}
