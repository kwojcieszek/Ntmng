using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ntmng.Model.Models;
using Ntmng.Web.Common;
using Ntmng.Web.Models;

namespace Ntmng.Web.Controllers;

public class ProductsController : Controller
{
    private readonly int _limitRows = 20;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;        
    }

    [Authorize(Roles = "products")]
    public async Task<ViewResult> Index(ProductsModel model)
    {
        var api = new ApiNtmng();
        var qunatity = await api.RestRequestAsync<int>($"products/count",RestSharp.Method.Get,authenticator: User.GetToken());

        return View(new ProductsModel() { GridView = new GridViewSettings() { QuantityRows = qunatity, RowsOnPage = _limitRows } });
    }

    public async Task<PartialViewResult> GridView(int limit, int offset = 0)
    {
        var api = new ApiNtmng();
        var products = await api.RestRequestAsync<ICollection<string>>($"products?limit={limit}&offset={offset}",RestSharp.Method.Get,
            authenticator: User.GetToken());

        return PartialView(new ProductsModel() { Products = products! });
    }
}