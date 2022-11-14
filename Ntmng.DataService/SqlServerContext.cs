namespace Ntmng.DataService;

public class SqlServerContext : Database
{
    public SqlServerContext() : base(new DatabaseSettings(DatabaseTypes.SqlServer, "Server=10.10.254.5;Database=Ntmng;User Id=ntmng;Password=A3AEcFfJTG3S;TrustServerCertificate=True;"))
    {
    }

    public override void Migrate()
    {
        base.Migrate();
    }
}