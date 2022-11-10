namespace Ntmng.DataService;

public class SqliteContext : Database
{
    public SqliteContext() : base(new DatabaseSettings(DatabaseTypes.Sqlite, "Data Source=Ntmng.db;"))
    {
    }

    public override void Migrate()
    {
        base.Migrate();
    }
}