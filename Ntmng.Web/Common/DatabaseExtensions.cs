namespace Ntmng.Web.Common;

public static class DatabaseExtensions
{
    public static IApplicationBuilder UseNtmngApi(this IApplicationBuilder app, IConfiguration configuration)
    {
        var url = configuration["Ntmng.Api:URL"];

        ApiNtmng.Url = url;

        return app;
    }
}