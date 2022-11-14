using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ntmng.DataService;
using Ntmng.Model.Models;

namespace Ntmng.Api.Controllers.Countries;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize]
public class CountriesController : ControllerBase
{
    private readonly ILogger<CountriesController> _logger;

    public CountriesController(ILogger<CountriesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetCountries")]
    public IEnumerable<Country> Get(int limit = int.MaxValue, int offset = 0)
    {
        return new Database().Countries.Skip(offset).Take(limit);
    }

    [HttpGet("Count", Name = "GetCount")]
    public int Count()
    {
        return new Database().Countries.Count();
    }
}