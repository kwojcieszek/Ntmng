using System.Security.Claims;

namespace Ntmng.Api.Common;

public static class ClaimsPrincipalExtensions
{
    public static int? UserId(this ClaimsPrincipal claim)
    {
        int userId;

        var claimsIdentity = claim.Identity as ClaimsIdentity;
        var userIdString = claimsIdentity!.FindFirst(ClaimTypes.PrimarySid)?.Value;

        return int.TryParse(userIdString, out userId) ? userId : null;
    }
}