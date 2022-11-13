using System.Text;
using Ntmng.Common;
using Ntmng.DataService;

namespace Ntmng.Api.Common;

public static class PasswordExtensions
{
    public static IApplicationBuilder UsePasswordSha256(this IApplicationBuilder app)
    {
        var configuration = app.ApplicationServices.GetService<IConfiguration>();

        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        var saltString = configuration["Password:Salt"];
        
        var salt = Encoding.GetEncoding("UTF-8").GetBytes(saltString!.ToCharArray());
      
        PasswordSha256.Salt = salt;
      
        return app;
    }
}