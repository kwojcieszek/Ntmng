using Microsoft.AspNetCore.Mvc;
using Ntmng.Web.Common;
using Ntmng.Web.Models;

namespace Ntmng.Web.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAuthentication _authentication;

    public AccountController(ILogger<HomeController> logger, IAuthentication authentication)
    {
        _logger = logger;
        _authentication = authentication;
    }

    public IActionResult SignIn()
    {
        return View();
    }

    public IActionResult SignOutAction()
    {
        _authentication.SignOut(this.HttpContext,User.Identity?.Name!);

        return View("SignIn");
    }

    //SignOutAction
    public IActionResult SignInAccept(SignInViewModel model)
    {
        _authentication.SignIn(HttpContext, model.Email, model.Password);

        var user = User.Identity;

        return RedirectToAction("Index", "Home");
    }
}