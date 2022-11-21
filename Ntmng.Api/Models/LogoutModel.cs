using System.ComponentModel.DataAnnotations;

namespace Ntmng.Api.Models;

public class LogoutModel
{
    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Token is required")]
    public string Token { get; set; }
}