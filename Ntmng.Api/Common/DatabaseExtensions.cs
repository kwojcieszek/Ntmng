using Ntmng.DataService;

namespace Ntmng.Api.Common;

public static class DatabaseExtensions
{
    public static IApplicationBuilder UseDatabase(this IApplicationBuilder app)
    {
        var configuration = app.ApplicationServices.GetService<IConfiguration>();

        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        var connectionString = configuration["DatabaseSettings:ConnectionStrings"];
        var databaseType = configuration.GetValue<DatabaseTypes>("DatabaseSettings:DatabaseType");

        Database.DatabaseSettings = new DatabaseSettings(databaseType, connectionString!);

        return app;
    }
}