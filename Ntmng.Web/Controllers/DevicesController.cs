using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ntmng.Model.Models;
using Ntmng.Web.Common;
using Ntmng.Web.Models;

namespace Ntmng.Web.Controllers;

public class DevicesController : Controller
{
    private readonly int _limitRows = 15;
    private readonly ILogger<CountriesController> _logger;

    public DevicesController(ILogger<CountriesController> logger)
    {
        _logger = logger;
    }

    [Authorize(Roles = "products")]
    public async Task<ViewResult> Index(DevicesModel model)
    {
        var api = new ApiNtmng();
        var qunatity = await api.RestRequestAsync<int>($"devices/quantity", RestSharp.Method.Get, authenticator: User.GetToken());
        
        return View(new DevicesModel() { GridView = new GridViewSettings() { QuantityRows = qunatity, RowsOnPage = _limitRows, RestApiPath = "devices", GridID = "gridview" } });
    }

    [Authorize(Roles = "products")]
    public async Task<PartialViewResult> GridView1(DevicesModel model)
    {
        var api = new ApiNtmng();
        var qunatity = await api.RestRequestAsync<int>($"devices/quantity", RestSharp.Method.Get, authenticator: User.GetToken());

        return PartialView(new DevicesModel() { GridView = new GridViewSettings() { QuantityRows = qunatity, RowsOnPage = _limitRows, RestApiPath = "devices" } });
    }

    public async Task<PartialViewResult> GridView(int limit, int offset = 0)
    {
        var api = new ApiNtmng();
        var devices = await api.RestRequestAsync<ICollection<Device>>($"devices?limit={limit}&offset={offset}", RestSharp.Method.Get,
            authenticator: User.GetToken());

        return PartialView(new DevicesModel() { Devices = devices! });
    }
}