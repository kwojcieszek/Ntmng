namespace Ntmng.DataService;

public class SqlServerContext : Database
{
    public SqlServerContext() : base(new DatabaseSettings(DatabaseTypes.SqlServer, "Server=10.10.254.5;Database=Ntmng;User Id=Ntmng;Password=A3AEcFfJTG3S;"))
    {
    }

    public override void Migrate()
    {
        base.Migrate();
    }
}