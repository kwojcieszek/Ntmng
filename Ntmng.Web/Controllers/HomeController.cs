using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ntmng.Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public ViewResult Index()
    {
        return View();
    }

    public ViewResult AccessDenied()
    {
        return View();
    }

    public ViewResult Privacy()
    {
        return View();
    }
}