using SQLite;

namespace Proyecto3_pago;

public class DatabaseService
{
    private readonly SQLiteConnection _connection;
    public DatabaseService(string databasePath = "testdb.db")
    {
        string fullPath = DatabasePathHelper.GetDatabasePath(databasePath);
        _connection = new SQLiteConnection(fullPath);
        _connection.CreateTable<Customer>();
    }
}

// Define the Customer class if it does not exist elsewhere
public class Customer
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public required string Name { get; set; }
}