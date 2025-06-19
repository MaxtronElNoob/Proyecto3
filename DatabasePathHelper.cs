namespace Proyecto3_pago;

public static class DatabasePathHelper
{
    public static string GetDatabasePath(string databaseName)
    {
        // Get the path to the local folder
        string folderPath = FileSystem.Current.AppDataDirectory;

        string fullPath = Path.Combine(folderPath, databaseName);

        if (!Directory.Exists(folderPath))
        {
            // Create the directory if it does not exist
            Directory.CreateDirectory(folderPath);
        }
        
        // Combine the folder path with the database name
        return fullPath;
    }
}