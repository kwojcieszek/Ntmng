using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ntmng.Common;
using Ntmng.DataService;
using Ntmng.Model.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ntmng.Common.Extensions;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Ntmng.Api.Common;

public class Authentication
{
    private readonly IPasswordService? _passwordService;
    public static string JwtValidIssuer { get; set; }
    public static string JwtValidAudience { get; set; }
    public static string JwtSecret { get; set; }
    public JwtSecurityToken SecurityToken { get; private set; }

    public Authentication(IPasswordService? passwordService = null)
    {
        _passwordService = passwordService;
    }

    public bool Auth(string userName, string password, int expiresMinutes = 1440)
    {
        var db = new Database();

        var user = db.Users.FirstOrDefault(u => u.UserName == userName);

        if (user == null)
            return false;

        if (_passwordService == null)
            throw new NoNullAllowedException("IPasswordService is not acceptable for method Auth");

        if (_passwordService.ComparePassword(password, user.Password))
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.PrimarySid, user.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.GivenName, user.FirstName));
            claims.Add(new Claim(ClaimTypes.Surname, user.LastName));
            if (user.MobilePhone != null)
            {
                claims.Add(new Claim(ClaimTypes.MobilePhone, user.MobilePhone));
            }

            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var userRoles = db.UserRoles.Where(r => r.UserId == user.UserId)
                .Include(r => r.Role);

            foreach (UserRole userRole in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret));

            SecurityToken = new JwtSecurityToken(
                issuer: JwtValidIssuer,
                audience: JwtValidAudience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(expiresMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            db.Tokens.Add(new Token()
            {
                SecretKey = authSigningKey.Key.ToStringFromArrary(),
                ValidFrom = SecurityToken.ValidFrom,
                ValidTo = SecurityToken.ValidTo
            });

            db.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public void Revoke()
    {
        var securityToken = new JwtSecurityToken();

    }
}