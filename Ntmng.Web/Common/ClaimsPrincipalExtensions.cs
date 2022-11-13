using System;
using System.Security.Claims;

namespace Ntmng.Web.Common;

public static class ClaimsPrincipalExtensions
{
    public static string? GetToken(this ClaimsPrincipal user)
    {
        if (user.Identity != null && user.Identity.IsAuthenticated)
        {
            var claim = user.Claims.Where(c => c.Type == "Token").FirstOrDefault();

            if (claim != null)
                return claim.Value;
        }

        return null;
    }

    public static string? GetLanguageCode(this ClaimsPrincipal user)
    {
        if (user.Identity != null && user.Identity.IsAuthenticated)
        {
            var claim = user.Claims.Where(c => c.Type == "LanguageCode").FirstOrDefault();

            if (claim != null)
                return claim.Value;
        }

        return null;
    }
}


