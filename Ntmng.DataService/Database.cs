using Microsoft.EntityFrameworkCore;
using Ntmng.Model.Models;

namespace Ntmng.DataService;

public class Database : DbContext
{
    #region Tables

    public DbSet<Country> Countries { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Localization> Localizations { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<ModuleData> ModulesData { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    #endregion

    public static DatabaseSettings DatabaseSettings { get; set; }

    public Database()
    {
    }

    public Database(DatabaseSettings databaseSettings)
    {
        DatabaseSettings = databaseSettings;
    }

    public virtual void Migrate()
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        InitData.Init(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = DatabaseSettings.DatabaseType switch
        {
            DatabaseTypes.Memory => optionsBuilder.UseInMemoryDatabase(DatabaseSettings.ConnectionString),
            DatabaseTypes.SqlServer => optionsBuilder.UseSqlServer(DatabaseSettings.ConnectionString),
            DatabaseTypes.Sqlite => optionsBuilder.UseSqlite(DatabaseSettings.ConnectionString),
            DatabaseTypes.PostgreSql => optionsBuilder.UseNpgsql(DatabaseSettings.ConnectionString),
            _ => throw new NotImplementedException()
        };
    }
}