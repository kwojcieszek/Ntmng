using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ntmng.Api.Common;
using Ntmng.Api.Models;
using Ntmng.Common;

namespace Ntmng.Api.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthenticateController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    [Route("login")]
    public Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var authentication = new Authentication(model.Username, model.Password, new PasswordSha256());

        if (authentication.IsAuthenticated)
        {
            return Task.FromResult<IActionResult>(Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(authentication.SecurityToken),
                expiration = authentication.SecurityToken.ValidTo
            }));
        }
        return Task.FromResult<IActionResult>(Unauthorized());
    }
}
