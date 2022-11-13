using System;
namespace Ntmng.Web.Common;

public interface IAuthentication
{
    public bool SignIn(HttpContext httpContext,string username, string password);

    public void SignOut(HttpContext httpContext, string username);

    public string? GetToken(HttpContext httpContext);
}