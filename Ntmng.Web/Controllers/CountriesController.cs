using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ntmng.Model.Models;
using Ntmng.Web.Common;
using Ntmng.Web.Models;

namespace Ntmng.Web.Controllers;

public class CountriesController : Controller
{
    private readonly int _limitRows = 15;
    private readonly ILogger<CountriesController> _logger;

    public CountriesController(ILogger<CountriesController> logger)
    {
        _logger = logger;
    }

    [Authorize(Roles = "products")]
    public async Task<ViewResult> Index(CountriesModel model)
    {
        var api = new ApiNtmng();
        var qunatity = await api.RestRequestAsync<int>($"countries/count", RestSharp.Method.Get, authenticator: User.GetToken());

        return View(new CountriesModel() { GridView = new GridViewSettings() { QuantityRows = qunatity, RowsOnPage = _limitRows, RestApiPath = "countries", GridID = "gridview" } });
    }

    [Authorize(Roles = "products")]
    public async Task<PartialViewResult> GridView1(CountriesModel model)
    {
        var api = new ApiNtmng();
        var qunatity = await api.RestRequestAsync<int>($"countries/count", RestSharp.Method.Get, authenticator: User.GetToken());

        return PartialView(new CountriesModel() { GridView = new GridViewSettings() { QuantityRows = qunatity, RowsOnPage = _limitRows, RestApiPath = "countries"} });
    }

    public async Task<PartialViewResult> GridView(int limit, int offset = 0)
    {
        var api = new ApiNtmng();
        var countries = await api.RestRequestAsync<ICollection<Country>>($"countries?limit={limit}&offset={offset}", RestSharp.Method.Get,
            authenticator: User.GetToken());

        return PartialView(new CountriesModel() { Countries = countries! });
    }
}