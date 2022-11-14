using System.Security.Claims;

namespace Ntmng.Api.Common;

public static class ClaimsPrincipalExtensions
{
    public static int? UserId(this ClaimsPrincipal claim)
    {
        var claimsIdentity = claim.Identity as ClaimsIdentity;
        var userIdString = claimsIdentity!.FindFirst(ClaimTypes.PrimarySid)?.Value;

        return int.TryParse(userIdString, out int userId) ? userId : null;
    }
}