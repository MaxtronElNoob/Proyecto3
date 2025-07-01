using SQLite;

namespace Proyecto3_pago;

public class DatabaseService
{
    SQLiteAsyncConnection database;

    async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await database.CreateTableAsync<TodoItem>();
        //Habilitar claves foraneas
        await database.ExecuteAsync("PRAGMA foreign_keys = ON;");
    }
}
