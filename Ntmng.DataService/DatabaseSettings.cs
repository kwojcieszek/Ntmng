namespace Ntmng.DataService;

public class DatabaseSettings
{
    public DatabaseTypes DatabaseType { get; set; }
    public string ConnectionString { get; set; }

    public DatabaseSettings(DatabaseTypes databaseType, string connectionString)
    {
        DatabaseType = databaseType;
        ConnectionString = connectionString;
    }
}