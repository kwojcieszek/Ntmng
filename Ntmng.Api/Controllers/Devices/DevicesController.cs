using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ntmng.Api.Common;
using Ntmng.DataService;
using Ntmng.Model.Models;

namespace Ntmng.Api.Controllers.Devices;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
[Authorize]
public class DevicesController : ControllerBase
{
    private readonly ILogger<DevicesController> _logger;

    public DevicesController(ILogger<DevicesController> logger)
    {
        _logger = logger;
    }

    [ApiVersion("1.0")]
    [HttpGet]
    public IEnumerable<Device> Get(int limit = int.MaxValue, int offset = 0)
    {
        var userId = User.UserId();

        if(!userId.HasValue)
            return Enumerable.Empty<Device>();

        return new Database().Devices.Where(r=> r.UserId == userId).Skip(offset).Take(limit);
    }

    [ApiVersion("1.0")]
    [HttpGet("Count")]
    public int Count()
    {
        var userId = User.UserId();

        if (!userId.HasValue)
            return 0;

        return new Database().Devices.Count(r => r.UserId == userId);
    }
}