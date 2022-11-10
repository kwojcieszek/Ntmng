using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ntmng.Api.Common;
using Ntmng.DataService;
using Ntmng.Model.Models;

namespace Ntmng.Api.Controllers.Products;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get(int limit = int.MaxValue, int offset = 0)
    {
        return new Database().Products.Skip(offset).Take(limit);
    }

    [HttpGet("Count", Name = "GetCount")]
    public int Count()
    {
        return new Database().Products.Count();
    }
}