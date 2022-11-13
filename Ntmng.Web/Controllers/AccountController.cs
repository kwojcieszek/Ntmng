﻿using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ntmng.Model.Models;
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

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult LoginAccept(LoginViewModel model)
    {
        _authentication.SignIn(HttpContext, model.Email, model.Password);

        var user = User.Identity;

        return RedirectToAction("Index", "Home");
    }
}