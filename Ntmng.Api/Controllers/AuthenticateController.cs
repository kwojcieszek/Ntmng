using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ntmng.Api.Common;
using Ntmng.Api.Models;
using Ntmng.Common;
using System.IdentityModel.Tokens.Jwt;

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

    [HttpPost(template:"login")]
    public Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var authentication = new Authentication(new PasswordSha256());
        
        if (authentication.Auth(model.Username, model.Password))
        {
            return Task.FromResult<IActionResult>(Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(authentication.SecurityToken),
                expiration = authentication.SecurityToken.ValidTo
            }));
        }
        return Task.FromResult<IActionResult>(Unauthorized());
    }

    [Authorize]
    [HttpPost(template: "revoke-token")]
    public Task<IActionResult> RevokeToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();


        foreach (var userClaim in this.User.Claims)
        {
            
        }
        var result = this.SignOut(JwtBearerDefaults.AuthenticationScheme);

        return Task.FromResult<IActionResult>(result);
    }
}