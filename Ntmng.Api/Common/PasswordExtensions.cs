﻿using Ntmng.Common;
using System.Text;

namespace Ntmng.Api.Common;

public static class PasswordExtensions
{
    public static IApplicationBuilder UsePasswordSha256(this IApplicationBuilder app)
    {
        var configuration = app.ApplicationServices.GetService<IConfiguration>();

        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration));

        var saltString = configuration["Password:Salt"];

        PasswordSha256.Salt = Encoding.GetEncoding("UTF-8").GetBytes(saltString!.ToCharArray());

        return app;
    }
}