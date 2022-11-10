namespace Ntmng.DataService;

public class MemoryContext : Database
{
    public MemoryContext() : base(new DatabaseSettings(DatabaseTypes.Memory, ""))
    {
    }

    public override void Migrate()
    {
        base.Migrate();
    }
}