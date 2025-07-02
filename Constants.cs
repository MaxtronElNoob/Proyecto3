namespace Proyecto3_pago;
public static class Constants
{
    public const string DatabaseFilename = "testdb.db";

    public const SQLite.SQLiteOpenFlags Flags =
        // open the database in read/write mode
        SQLite.SQLiteOpenFlags.ReadWrite |
        // create the database if it doesn't exist
        SQLite.SQLiteOpenFlags.Create |
        // enable multi-threaded database access
        SQLite.SQLiteOpenFlags.SharedCache;

    // Asegura que la carpeta exista antes de devolver la ruta
    public static string DatabasePath {
        get {
            var dbDir = Path.Combine(FileSystem.AppDataDirectory);
            if (!Directory.Exists(dbDir))
                Directory.CreateDirectory(dbDir);
            return Path.Combine(dbDir, DatabaseFilename);
        }
    }
}
