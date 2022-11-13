using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Ntmng.Web.Common;

public class ApiAuthentication : IAuthentication
{
    public string? GetToken(HttpContext httpContext)
    {
        if (httpContext.User.Identity != null && httpContext.User.Identity.IsAuthenticated)
        {
            var claim = httpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault();

            if (claim != null)
                return claim.Value;
        }

        return null;
    }

    public bool SignIn(HttpContext httpContext, string userName, string password)
    {
        var result = ApiLogIn(userName, password);

        if (result == null)
            return false;

        var user = httpContext.User;

        var claims = GetClaims(userName, result.token);

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.LoginPath);

        var authProperties = new AuthenticationProperties
        {
            //AllowRefresh = <bool>,
            //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            IsPersistent = true,
            //IssuedUtc = <DateTimeOffset>,
            //RedirectUri = <string>
        };

        httpContext.SignInAsync(
           CookieAuthenticationDefaults.AuthenticationScheme,
           new ClaimsPrincipal(claimsIdentity),
           authProperties);

        return true;
    }

    public void SignOut(HttpContext httpContext, string username)
    {

    }

    private authresult? ApiLogIn(string userName, string password)
    {
        var api = new ApiNtmng();

        return api.RestRequest<authresult>("authenticate/login", RestSharp.Method.Post, new { username = userName, password = password });

    }

    private List<Claim> GetClaims(string userName, string token)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim("FullName", userName),
            new Claim("LanguageCode", "pl-PL"),
            new Claim("Token", token),
            new Claim(ClaimTypes.Role, "products"),
            //"en-EN"
        };
        return claims;
    }
}

public class auth
{
    public string username { get; set; }
    public string password { get; set; }
}

public class authresult
{
    public string token { get; set; }
    public DateTime expiration { get; set; }
}