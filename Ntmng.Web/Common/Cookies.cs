using Microsoft.AspNetCore.Mvc;

namespace Ntmng.Web.Common;

public class Cookies
{
    private readonly Controller _controller;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public Cookies(Controller controller, IHttpContextAccessor httpContextAccessor)
    {
        _controller = controller;
        _httpContextAccessor = httpContextAccessor;
    }

    public string? Get(string key)
    {
        var cookieValueFromContext  = _httpContextAccessor.HttpContext?.Request.Cookies["key"];

        return _controller.Request.Cookies["Key"];
    }

    public void Set(string key, string value, int? expireTime)
    {
        var option = new CookieOptions
        {
            Expires = expireTime.HasValue ? DateTime.Now.AddMinutes(expireTime.Value) : DateTime.Now.AddMilliseconds(10)
        };

        _controller.Response.Cookies.Append(key, value, option);
    }

    public void Remove(string key)
    {
        _controller.Response.Cookies.Delete(key);
    }
}

