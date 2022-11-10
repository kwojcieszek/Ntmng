namespace Ntmng.DataService;

public class PostgreSqlContext : Database
{
    public PostgreSqlContext() : base(new DatabaseSettings(DatabaseTypes.PostgreSql, ""))
    {
    }

    public override void Migrate()
    {
        base.Migrate();
    }
}