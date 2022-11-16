using System.Security.Claims;

namespace Ntmng.Web.Common;

public static class ClaimsPrincipalExtensions
{
    public static string? GetToken(this ClaimsPrincipal user)
    {
        if (user.Identity != null && user.Identity.IsAuthenticated)
        {
            var claim = user.Claims.FirstOrDefault(c => c.Type == "Token");

            if (claim != null)
                return claim.Value;
        }

        return null;
    }

    public static string? GetLanguageCode(this ClaimsPrincipal user)
    {
        if (user.Identity != null && user.Identity.IsAuthenticated)
        {
            var claim = user.Claims.FirstOrDefault(c => c.Type == "LanguageCode");

            if (claim != null)
                return claim.Value;
        }

        return null;
    }
}


