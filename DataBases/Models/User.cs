using SQLite;

namespace Proyecto3_pago.DataBases.Models;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Name { get; set; }
    public int Earnings { get; set; }
    public int Spending { get; set; }

    [Ignore]
    public int Balance => Earnings - Spending;
}
