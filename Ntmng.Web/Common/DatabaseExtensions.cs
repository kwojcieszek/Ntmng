namespace Ntmng.Web.Common;

public static class DatabaseExtensions
{
    public static IApplicationBuilder UseNtmngApi(this IApplicationBuilder app, IConfiguration configuration)
    {
        ApiNtmng.Url = configuration["Ntmng.Api:URL"];

        return app;
    }
}